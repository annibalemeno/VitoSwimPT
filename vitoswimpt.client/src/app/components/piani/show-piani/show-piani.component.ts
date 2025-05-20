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

    ngOnInit(): void {
      this.refreshPianiList();
    }

  public refreshPianiList() {
    this.service.getPianiList().subscribe(data => {
      this.PianiList = data;
      console.log("PianiList", this.PianiList);
     /* this.EserciziListWithoutFilter = data;*/
    });
  }
}



//pianoId: number;
//nomePiano: string;
//descrizione: string;
//note: string;
