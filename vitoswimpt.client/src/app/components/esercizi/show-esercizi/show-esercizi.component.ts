import { Component, OnInit } from '@angular/core';
import { Esercizi } from '../../../interfaces/esercizi';
import { ApiserviceService } from '../../../apiservice.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-show-esercizi',
  standalone: false,
  templateUrl: './show-esercizi.component.html',
  styleUrl: './show-esercizi.component.css'
})
export class ShowEserciziComponent implements OnInit {

  constructor(private service: ApiserviceService) { }

  public EserciziList: Esercizi[] = [];
  // EserciziList: any = [];
  ModalTitle = "";
  ActivateAddEditEsercComp: boolean = false;
  eserc: Esercizi 
    = {
    esercizioId: 0,
    ripetizioni: 0,
    distanza: 0,
    recupero: 0,
    stile: "Libero"
  };

  EserciziIdFilter = "";
  EerciziRipetizioniFilter = "";
  EerciziDistanzaFilter = "";
  EerciziRecuperoFilter = "";
  EerciziStileFilter = "";
  EserciziListWithoutFilter: any = [];

  ngOnInit(): void {
        this.refreshEserciziList();
        //this.getAllenamenti();
  }

  addClick() {
    this.eserc = {
      esercizioId: 0,
      ripetizioni: 0,
      distanza: 0,
      recupero: 0,
      stile: "Libero"
    };
    
    this.ModalTitle = "Add Esercizio";
    this.ActivateAddEditEsercComp = true;
  }

  editClick(item: any) {
    this.eserc = item;

    //this.eserc = {
    //  esercizioId: item.esercizioId,
    //  ripetizioni: item.ripetizioni,
    //  distanza: item.distanza,
    //  recupero: item.recupero,
    //  stile: item.stile
    //};

    this.ModalTitle = "Edit Esercizio";
    this.ActivateAddEditEsercComp = true;
  }

  deleteClick(item: any) {
    if (confirm('Are you sure??')) {

      this.service.deleteEsercizio(item.esercizioId).subscribe(data => {
        alert('delete ok');
        this.refreshEserciziList();
      });
    }
  }


  closeClick() {
    this.ActivateAddEditEsercComp = false;
    this.refreshEserciziList();
  }


  refreshEserciziList() {
    this.service.getEserciziList().subscribe(data => {
      this.EserciziList = data;
      this.EserciziListWithoutFilter = data;
    });
  }
 
  sortResult(prop: any, asc: any) {
    this.EserciziList = this.EserciziListWithoutFilter.sort(function (a: any, b: any) {
      if (asc) {
        return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
      }
      else {
        return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
      }
    });
  }

  FilterFn() {
    var EserciziIdFilter = this.EserciziIdFilter;
    var RipetizioniFilter = this.EerciziRipetizioniFilter;
    var DistanzaFilter = this.EerciziDistanzaFilter;
    var RecuperoFilter = this.EerciziRecuperoFilter;
    var StileFilter = this.EerciziStileFilter;

    this.EserciziList = this.EserciziListWithoutFilter.filter(
      function (el: any) {
        return el.esercizioId.toString().toLowerCase().includes(
          EserciziIdFilter.toString().trim().toLowerCase()
        ) && el.ripetizioni.toString().toLowerCase().includes(
          RipetizioniFilter.toString().trim().toLowerCase())
          && el.distanza.toString().toLowerCase().includes(
            DistanzaFilter.toString().trim().toLowerCase())
          && el.recupero.toString().toLowerCase().includes(
            RecuperoFilter.toString().trim().toLowerCase())
          && el.stile.toString().toLowerCase().includes(
            StileFilter.toString().trim().toLowerCase())
      }
    );
  }
}
