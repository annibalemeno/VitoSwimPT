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
  training: Allenamenti
    = {
      allenamentoId: 0,
      nomeAllenamento: "",
      note: ""
    };


  AllenamentiiListWithoutFilter: any = [];

  AllenamentiIdFilter = "";
  NomeAllenamentiFilter = "";
  NoteAllenamentiFilter = "";

  ngOnInit(): void {
    this.refreshAllenamentiList();
  }

  addClick() {
    //initialize
    this.training = {
      allenamentoId: 0,
      nomeAllenamento: "",
      note: ""
    };

    this.ModalTitle = "Add Allenamento";
    this.ActivateAddEditAllenamComp = true;
  }

  editClick(item: any) {
    this.training = item;

    //this.eserc = {
    //  esercizioId: item.esercizioId,
    //  ripetizioni: item.ripetizioni,
    //  distanza: item.distanza,
    //  recupero: item.recupero,
    //  stile: item.stile
    //};

    this.ModalTitle = "Edit Allenamento";
    this.ActivateAddEditAllenamComp = true;
  }

  closeClick() {
    this.ActivateAddEditAllenamComp = false;
    this.refreshAllenamentiList();
  }

  deleteClick(item:any) {
    if (confirm('Are you sure??')) {
      this.service.deleteAllenamento(item.allenamentoId).subscribe(data => {
        alert('delete ok');
        this.refreshAllenamentiList();
      });
    }
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
