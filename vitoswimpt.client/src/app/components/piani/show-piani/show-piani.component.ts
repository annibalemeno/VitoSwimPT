import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';
import { Piani } from '../../../interfaces/piani';
import { AccountService } from '../../../infrastructure/account.service';

@Component({
  selector: 'app-show-piani',
  standalone: false,
  templateUrl: './show-piani.component.html',
  styleUrl: './show-piani.component.css'
})
export class ShowPianiComponent implements OnInit{

  constructor(private service: ApiserviceService, private authService: AccountService) { }

  public PianiList: Piani[] = [];
  PianiIdFilter = "";
  NomePianoFilter = "";
  DescrizioneFilter = "";
  NoteFilter = "";

  PianiListWithoutFilter: any = [];

  ModalTitle = "";
  ActivateAddEditPianiComp: boolean = false;
  plan: Piani = {
    pianoId: 0,
    nomePiano: "",
    descrizione: "",
    note: "",
    username: ""
  };

    ngOnInit(): void {
      this.refreshPianiList();
    }

  public refreshPianiList() {
    if (this.authService.email != null) {
      let email = this.authService.email;
      this.service.getPianiByUser(email).subscribe(data => {
        this.PianiList = data;
        console.log("PianiList", this.PianiList);
        this.PianiListWithoutFilter = data;
      });
    }
  }

  sortResult(prop: any, asc: any) {
    this.PianiList = this.PianiListWithoutFilter.sort(function (a: any, b: any) {
      if (asc) {
        return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
      }
      else {
        return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
      }
    });
  }

  FilterFn() {
    var PianiIdFilter = this.PianiIdFilter;
    var NomePianoFilter = this.NomePianoFilter;
    var DescrizioneFilter = this.DescrizioneFilter;
    var NoteFilter = this.NoteFilter;

    this.PianiList = this.PianiListWithoutFilter.filter(
      function (el: any) {
        return el.pianoId.toString().toLowerCase().includes(
          PianiIdFilter.toString().trim().toLowerCase()
        ) && el.nomePiano.toString().toLowerCase().includes(
          NomePianoFilter.toString().trim().toLowerCase()
        ) && el.descrizione.toString().toLowerCase().includes(
          DescrizioneFilter.toString().trim().toLowerCase())
          && el.note.toString().toLowerCase().includes(
            NoteFilter.toString().trim().toLowerCase())
      }
    );
  }

  addClick() {
    this.plan = {
      pianoId: 0,
      nomePiano: "",
      descrizione: "",
      note: "",
      username: this.authService.email!
    };

    this.ModalTitle = "Add Piano";
    this.ActivateAddEditPianiComp = true;
  }

  closeClick() {
    this.ActivateAddEditPianiComp = false;
    this.refreshPianiList();
  }

  editClick(item: any) {
    this.plan = {
      pianoId: item.pianoId,
      nomePiano: item.nomePiano,
      descrizione: item.descrizione,
      note: item.note,
      username: this.authService.email!
    };

/*    this.plan = item;*/

    this.ModalTitle = "Edit Piano";
    this.ActivateAddEditPianiComp = true;
  }

  deleteClick(item: any) {
    if (confirm('Are you sure??')) {

      this.service.deletePiano(item.pianoId).subscribe(data => {
        alert('delete ok');
        this.refreshPianiList();
      });
    }
  }

}

