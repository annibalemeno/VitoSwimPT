import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EserciziComponent } from './components/esercizi/esercizi.component';
import { AllenamentiComponent } from './components/allenamenti/allenamenti.component';
import { DetailAllenamentiComponent } from './components/allenamenti/detail-allenamenti/detail-allenamenti.component';
import { DetailPianiComponent} from './components/piani/detail-piani/detail-piani.component'
import { PianiComponent } from './components/piani/piani.component'
import { LoginUserComponent } from './components/user/login-user/login-user.component'
import {HomeComponent } from './components/home/home.component'


/*{ path: '', redirectTo: '/login', pathMatch: 'full' },*/

const routes: Routes = [
  { path: 'esercizi', component: EserciziComponent },
  { path: 'allenamenti', component: AllenamentiComponent },
  { path: 'trainDetail/:id', component: DetailAllenamentiComponent },
  { path: 'pianiDetail/:id', component: DetailPianiComponent },
  { path: 'piani', component: PianiComponent },
  { path: 'login', component: LoginUserComponent },
  { path: 'home', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


