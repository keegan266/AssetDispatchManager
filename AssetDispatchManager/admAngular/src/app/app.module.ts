import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AppFormComponent } from './appForm/appForm.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AppFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppFormComponent]
})
export class AppModule { }
