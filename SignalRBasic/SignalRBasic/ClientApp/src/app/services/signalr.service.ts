import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { ChartModel } from './ChartModel';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  public data!: ChartModel[] | any[];

  private hubConnection: signalR.HubConnection | any
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/chart')
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch((err: string) => console.log('Error while starting connection: ' + err))
  }

  public addTransferChartDataListener = () => {
    this.hubConnection.on('transferchartdata', (data: any[] | ChartModel[]) => {
      this.data = data;
      console.log(data);
    });
  }
}
