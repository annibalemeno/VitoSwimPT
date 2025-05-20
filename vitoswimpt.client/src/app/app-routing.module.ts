import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EserciziComponent } from './components/esercizi/esercizi.component';
import { AllenamentiComponent } from './components/allenamenti/allenamenti.component';
import { DetailAllenamentiComponent } from './components/allenamenti/detail-allenamenti/detail-allenamenti.component';
import { PianiComponent } from './components/piani/piani.component'

const routes: Routes = [
  { path: 'esercizi', component: EserciziComponent },
  { path: 'allenamenti', component: AllenamentiComponent },
  { path: 'trainDetail/:id', component: DetailAllenamentiComponent },
  { path: 'piani', component: PianiComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


