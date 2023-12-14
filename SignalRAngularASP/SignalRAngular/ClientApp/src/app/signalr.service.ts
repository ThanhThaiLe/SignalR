import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  hubUrl: string;
  connection: any;
  hubHelloMessage: BehaviorSubject<string>;
  constructor() {
    this.hubHelloMessage = new BehaviorSubject<string>('');
    this.hubUrl = window.location.href + 'MessageHub';
  }

  public async initiateSignalrConnection(): Promise<void> {
    try {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl(this.hubUrl)
        .withAutomaticReconnect()
        .build();

      await this.connection.start({ withCredentials: false });

      console.log(
        `SignalR connection success! connectionId: ${this.connection.connectionId}`
      );
    } catch (error) {
      console.log(`SignalR connection error: ${error}`);
    }
  }
}
