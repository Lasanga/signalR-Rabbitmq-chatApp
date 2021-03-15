import { Component, OnInit } from '@angular/core';
import { SignalRService } from './signal-r.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit{

  constructor(public signalRService: SignalRService) {
  }

  ngOnInit(): void {
    this.initChat();
    this.signalRService.addGroupChatListener();
  }

  private initChat(): void {
    this.signalRService.startConnection();
  }
}
