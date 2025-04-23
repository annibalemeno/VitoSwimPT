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
  ModalTitle = "";
  ActivateAddEditAllenamComp: boolean = false;

  AllenamentiiListWithoutFilter: any = [];

  AllenamentiIdFilter = "";
  NomeAllenamentiFilter = "";
  NoteAllenamentiFilter = "";

  ngOnInit(): void {

    //this.allenamentiList = [
    //  { allenamentoId: 11, nomeallenamento: 'Nome Mocked 11', note: 'Note Mocked 11' },
    //  { allenamentoId: 12, nomeallenamento: 'Nome Mocked 12', note: 'Note Mocked 12' }
    //];

    this.refreshAllenamentiList();
  }

  addClick() {
    //initialize

    this.ModalTitle = "Add Allenamento";
    this.ActivateAddEditAllenamComp = true;
  }
  closeClick() {
    this.ActivateAddEditAllenamComp = false;
    this.refreshAllenamentiList();
  }


  refreshAllenamentiList() {
    this.service.getAllenamentiList().subscribe(data => {
      this.allenamentiList = data;
      this.AllenamentiiListWithoutFilter = data;
    });
  }

  FilterFn() {
    var AllenamentiIdFilter = this.AllenamentiIdFilter;
    var NomeAllenamentiFilter = this.NomeAllenamentiFilter;
    var NoteAllenamentiFilter = this.NoteAllenamentiFilter;


    this.allenamentiList = this.AllenamentiiListWithoutFilter.filter(
      function (al: any) {
        return al.allenamentoId.toString().toLowerCase().includes(
          AllenamentiIdFilter.toString().trim().toLowerCase()
        ) && al.nomeAllenamento.toString().toLowerCase().includes(
          NomeAllenamentiFilter.toString().trim().toLowerCase())
          && al.note.toString().toLowerCase().includes(
            NoteAllenamentiFilter.toString().trim().toLowerCase())
      }
    );
  }

  sortResult(prop: any, asc: any) {
    this.allenamentiList = this.AllenamentiiListWithoutFilter.sort(function (a: any, b: any) {
      if (asc) {
        return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
      }
      else {
        return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
      }
    });
  }
}
