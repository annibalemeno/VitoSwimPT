import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';
import { Piani } from '../../../interfaces/piani';

@Component({
  selector: 'app-show-piani',
  standalone: false,
  templateUrl: './show-piani.component.html',
  styleUrl: './show-piani.component.css'
})
export class ShowPianiComponent implements OnInit{

  constructor(private service: ApiserviceService) { }

  public PianiList: Piani[] = [];
  PianiIdFilter = "";
  NomePianoFilter = "";
  DescrizioneFilter = "";
  NoteFilter = "";

  PianiListWithoutFilter:any = [];

    ngOnInit(): void {
      this.refreshPianiList();
    }

  public refreshPianiList() {
    this.service.getPianiList().subscribe(data => {
      this.PianiList = data;
      console.log("PianiList", this.PianiList);
      this.PianiListWithoutFilter = data;
    });
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

}



//pianoId: number;
//nomePiano: string;
//descrizione: string;
//note: string;
