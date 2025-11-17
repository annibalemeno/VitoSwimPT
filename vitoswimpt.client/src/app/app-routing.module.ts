import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EserciziComponent } from './components/esercizi/esercizi.component';
import { AllenamentiComponent } from './components/allenamenti/allenamenti.component';
import { DetailAllenamentiComponent } from './components/allenamenti/detail-allenamenti/detail-allenamenti.component';
import { DetailPianiComponent} from './components/piani/detail-piani/detail-piani.component'
import { PianiComponent } from './components/piani/piani.component'
import { LoginUserComponent } from './components/user/login-user/login-user.component'
import {RegisterUserComponent } from './components/user/register-user/register-user.component'
import {HomeComponent } from './components/home/home.component'
import { AuthGuard } from './infrastructure/auth.guard';


/*{ path: '', redirectTo: '/login', pathMatch: 'full' },*/

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },

  { path: 'esercizi', component: EserciziComponent, canActivate: [AuthGuard] },
  { path: 'allenamenti', component: AllenamentiComponent, canActivate: [AuthGuard] },
  { path: 'trainDetail/:id', component: DetailAllenamentiComponent, canActivate: [AuthGuard] },
  { path: 'pianiDetail/:id', component: DetailPianiComponent, canActivate: [AuthGuard] },
  { path: 'piani', component: PianiComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginUserComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterUserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


