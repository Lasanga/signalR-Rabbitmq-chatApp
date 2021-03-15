import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import * as ApiServices from './service-proxies';
import { environment } from 'src/environments/environment';
import { API_BASE_URL } from './service-proxies';
import { HttpClientModule } from '@angular/common/http';

export function getApiBaseUrl(): string {
  return environment.apiUrl;
}
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [ApiServices.ChatService, { provide: API_BASE_URL, useFactory: getApiBaseUrl }],
  bootstrap: [AppComponent]
})
export class AppModule { }
