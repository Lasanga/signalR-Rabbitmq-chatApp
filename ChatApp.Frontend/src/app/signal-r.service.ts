import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ChatService } from './service-proxies';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  constructor(private readonly chatService: ChatService) { }

  private hubConnection: signalR.HubConnection;
  public messages: string[] = [];

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/chatHub`)
      .build();
    this.hubConnection
      .start()
      .then(() => this.getConnectionId())
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public getConnectionId() {
    this.hubConnection.invoke('getConnectionId')
    .then((connectionId: string) => {
      this.chatService.initChat(connectionId).pipe(take(1)).subscribe();
    });
  }

  public addGroupChatListener = () => {
    this.hubConnection.on('JoinGroup', (message: string) => {
      this.messages.push(message);
    });
  }
}
