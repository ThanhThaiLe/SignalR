import { Component, NgZone } from '@angular/core';
import { Message } from '../message.types';
import { ChatService } from '../chat.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = 'ClientApp';
  txtMessage: string = 'Hello';
  uniqueID: string = new Date().getTime().toString();
  messages = new Array<Message>();
  private message: Message = {
    clientuniqueid: '',
    type: '',
    message: '',
    date: new Date(),
  };

  constructor(private chatService: ChatService, private _ngZone: NgZone) {
    debugger;
    this.subscribeToEvents();
  }

  sendMessage(): void {
    debugger;
    this.message = {
      clientuniqueid: '',
      type: '',
      message: '',
      date: new Date(),
    };
    this.message.clientuniqueid = this.uniqueID;
    this.message.type = 'sent';
    this.message.message = this.txtMessage;
    this.message.date = new Date();
    this.messages.push(this.message);
    this.chatService.sendMessage(this.message);
    this.txtMessage = '';
  }
  private subscribeToEvents(): void {
    debugger;
    this.chatService.messageReceived.subscribe((message: Message) => {
      this._ngZone.run(() => {
        if (message.clientuniqueid !== this.uniqueID) {
          message.type = 'received';
          this.messages.push(message);
        }
      });
    });
  }
}
