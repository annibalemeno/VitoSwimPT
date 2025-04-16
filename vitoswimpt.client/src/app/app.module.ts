import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EserciziComponent } from './components/esercizi/esercizi.component';
import { ShowEserciziComponent } from './components/esercizi/show-esercizi/show-esercizi.component';
import { AddEditEserciziComponent } from './components/esercizi/add-edit-esercizi/add-edit-esercizi.component';
import { AllenamentiComponent } from './components/allenamenti/allenamenti.component';
import { ShowAllenamentiComponent } from './components/allenamenti/show-allenamenti/show-allenamenti.component';
import { AddEditAllenamentiComponent } from './components/allenamenti/add-edit-allenamenti/add-edit-allenamenti.component';

@NgModule({
  declarations: [
    AppComponent,
    EserciziComponent,
    ShowEserciziComponent,
    AddEditEserciziComponent,
    ShowAllenamentiComponent,
    AllenamentiComponent,
    AddEditAllenamentiComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
