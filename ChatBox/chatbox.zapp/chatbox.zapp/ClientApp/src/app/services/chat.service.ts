import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserModel } from '../models/user';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  myName: string = '';
  private chatConnection?: HubConnection;
  constructor(private http: HttpClient) {}
  registerUser(user: UserModel) {
    return this.http.post(`${environment.apiUrl}chat/register-user`, user, {
      responseType: 'text',
    });
  }
  createChatConnection() {
    this.chatConnection = new HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/hubs/chat`)
      .withAutomaticReconnect()
      .build();

    this.chatConnection.start().catch((error) => {
      console.log(error);
    });
  }

  stopChatConnection() {
    this.chatConnection?.stop().catch((error) => {
      console.log(error);
    });
  }
}
