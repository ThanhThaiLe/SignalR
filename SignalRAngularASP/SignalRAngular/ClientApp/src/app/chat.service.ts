import { EventEmitter, Injectable } from '@angular/core';
import { Message } from './message.types';
import {
  HttpTransportType,
  HubConnection,
  HubConnectionBuilder,
} from '@microsoft/signalr';

@Injectable()
export class ChatService {
  messageReceived = new EventEmitter<Message>();
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;
  private _hubConnection: HubConnection | any;

  constructor() {
    debugger;
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  sendMessage(message: Message) {
    this._hubConnection.invoke('NewMessage', message);
  }

  private createConnection() {
    console.log('window.location.href' + window.location.href);
    debugger;

    console.log('create connection hub start');
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(window.location.href + 'MessageHub', {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
      })
      .build();
    console.log('create connection hub done');
  }

  private startConnection(): void {
    debugger;

    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(() => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(() => {
          this.startConnection();
        }, 5000);
      });
  }

  private registerOnServerEvents(): void {
    debugger;

    this._hubConnection.on('MessageReceived', (data: any) => {
      this.messageReceived.emit(data);
    });
  }
}
