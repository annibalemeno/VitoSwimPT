import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
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
import { DetailAllenamentiComponent } from './components/allenamenti/detail-allenamenti/detail-allenamenti.component';
import { PianiComponent } from './components/piani/piani.component';
import { ShowPianiComponent } from './components/piani/show-piani/show-piani.component';
import { AddEditPianiComponent } from './components/piani/add-edit-piani/add-edit-piani.component';
import { DetailPianiComponent } from './components/piani/detail-piani/detail-piani.component';
import { authInterceptorInterceptor} from './infrastructure/auth-interceptor.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    EserciziComponent,
    ShowEserciziComponent,
    AddEditEserciziComponent,
    ShowAllenamentiComponent,
    AllenamentiComponent,
    AddEditAllenamentiComponent,
    DetailAllenamentiComponent,
    PianiComponent,
    ShowPianiComponent,
    AddEditPianiComponent,
    DetailPianiComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: authInterceptorInterceptor,
    multi: true,
  },],
  bootstrap: [AppComponent]
})
export class AppModule { }
