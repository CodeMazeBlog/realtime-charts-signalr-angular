import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { ChartModel } from '../_interfaces/chartdata.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data: ChartModel[] = [{data:[], label:''}, {data:[], label:''}, {data:[], label:''}, {data:[], label:''}];

private hubConnection: signalR.HubConnection

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:5001/chart')
                            .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addListener = () => {
    this.hubConnection.on('receivechartdata', (data) => {
      this.data = data;
      console.log(data);
    });
  }
}
