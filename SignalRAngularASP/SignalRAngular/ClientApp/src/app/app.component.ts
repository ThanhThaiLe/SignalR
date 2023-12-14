import { Component } from '@angular/core';
import { SignalrService } from './signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'app';
  hubHelloMessage?: string;

  constructor(public signalrService: SignalrService) {
    this.hubHelloMessage = '';
  }
  ngOnInit(): void {
    // this.signalrService.hubHelloMessage.subscribe((hubHelloMessage: string) => {
    //   this.hubHelloMessage = hubHelloMessage;
    // });
    // this.signalrService.connection.invoke('Hello').catch((error: any) => {
    //   console.log(`SignalrDemoHub.Hello() error: ${error}`);
    //   alert('SignalrDemoHub.Hello() error!, see console for details.');
    // });
  }
}
