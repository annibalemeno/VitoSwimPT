import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EserciziComponent } from './components/esercizi/esercizi.component';
import { ShowEserciziComponent } from './components/esercizi/show-esercizi/show-esercizi.component';
import { AddEditEserciziComponent } from './components/esercizi/add-edit-esercizi/add-edit-esercizi.component';

@NgModule({
  declarations: [
    AppComponent,
    EserciziComponent,
    ShowEserciziComponent,
    AddEditEserciziComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
