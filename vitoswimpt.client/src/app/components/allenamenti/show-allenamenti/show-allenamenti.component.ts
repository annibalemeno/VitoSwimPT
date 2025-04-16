import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';
import { Allenamenti } from '../../../interfaces/allenamenti';

@Component({
  selector: 'app-show-allenamenti',
  standalone: false,
  templateUrl: './show-allenamenti.component.html',
  styleUrl: './show-allenamenti.component.css'
})
export class ShowAllenamentiComponent implements OnInit {

  constructor(private service: ApiserviceService) { }


  public allenamentiList: Allenamenti[] = [];


  ngOnInit(): void {

    //this.allenamentiList = [
    //  { allenamentoId: 11, nomeallenamento: 'Nome Mocked 11', note: 'Note Mocked 11' },
    //  { allenamentoId: 12, nomeallenamento: 'Nome Mocked 12', note: 'Note Mocked 12' }
    //];

    this.refreshAllenamentiList();
  }

  refreshAllenamentiList() {
    this.service.getAllenamentiList().subscribe(data => {
      this.allenamentiList = data;
      //this.EserciziListWithoutFilter = data;
    });
  }
}
