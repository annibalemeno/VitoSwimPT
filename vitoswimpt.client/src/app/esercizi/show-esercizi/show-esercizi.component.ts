import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Esercizi {
  esercizioId: number;
  ripetizioni: string;
  distanza: number;
  recupero: number;
  stile: string;
}

@Component({
  selector: 'app-show-esercizi',
  standalone: false,
  templateUrl: './show-esercizi.component.html',
  styleUrl: './show-esercizi.component.css'
})
export class ShowEserciziComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public EserciziList: Esercizi[] = [];
  // EserciziList: any = [];
  ModalTitle = "";
  ActivateAddEditEsercComp: boolean = false;
  eserc: any;

  Esercizi_Id_Filter = "";
  Eercizi_Ripetizioni_Filter = "";
  EserciziListWithoutFilter: any = [];

  ngOnInit(): void {
        this.refreshEserciziList();
        //this.getAllenamenti();
  }

  addClick() {
    //this.eserc = {
    //  DepartmentId: "0",
    //  DepartmentName: ""
    //}
    this.ModalTitle = "Add Esercizio";
    this.ActivateAddEditEsercComp = true;
  }

  editClick(item: any) {
    this.eserc = item;
    this.ModalTitle = "Edit Esercizio";
    this.ActivateAddEditEsercComp = true;
  }

  deleteClick(item: any) {
    if (confirm('Are you sure??')) {
      //this.service.deleteDepartment(item.DepartmentId).subscribe(data => {
      //  alert(data.toString());
      //  this.refreshEserciziList();
      //})
      alert('ToDo');
    }
  }

  closeClick() {
    this.ActivateAddEditEsercComp = false;
    this.refreshEserciziList();
  }


  refreshEserciziList() {
    this.http.get<Esercizi[]>('/esercizi').subscribe(data => {
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
    debugger;
    var DepartmentIdFilter = this.Esercizi_Id_Filter;
    var DepartmentNameFilter = this.Eercizi_Ripetizioni_Filter;

    this.EserciziList = this.EserciziListWithoutFilter.filter(
      function (el: any) {
        return el
      }
    );
  }


  //getAllenamenti() {
  //  this.http.get<Esercizi[]>('/esercizi').subscribe(
  //    (result) => {
  //      this.esercizi = result;
  //    },
  //    (error) => {
  //      console.error(error);
  //    }
  //  );
  //}
}
