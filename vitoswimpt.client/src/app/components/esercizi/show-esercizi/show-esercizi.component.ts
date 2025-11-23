import { Component, OnInit } from '@angular/core';
import { Esercizi } from '../../../interfaces/esercizi';
import { ApiserviceService } from '../../../apiservice.service';
import { Stili } from '../../../interfaces/stili';
import { FilterItem } from '../../../interfaces/filter';

@Component({
  selector: 'app-show-esercizi',
  standalone: false,
  templateUrl: './show-esercizi.component.html',
  styleUrl: './show-esercizi.component.css'
})
export class ShowEserciziComponent implements OnInit {

  constructor(private service: ApiserviceService, ) { }
  stiliList: FilterItem[] = [];
  public eserciziList: Esercizi[] = [];

  ngOnInit(): void {
    this.refreshEserciziList();

    this.service.getStili().subscribe(data => {
        data.forEach(x => {
          this.stiliList.push({ label: x.nome, value: x.nome });
        });
    });



  }

  refreshEserciziList() {
    this.service.getEserciziList().subscribe(data => {
      this.eserciziList = data;
    });
  }



}
