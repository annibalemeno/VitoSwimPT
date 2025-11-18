import { Component, OnInit } from '@angular/core';
import { Esercizi } from '../../../interfaces/esercizi';
import { ApiserviceService } from '../../../apiservice.service';

@Component({
  selector: 'app-show-esercizi',
  standalone: false,
  templateUrl: './show-esercizi.component.html',
  styleUrl: './show-esercizi.component.css'
})
export class ShowEserciziComponent implements OnInit {

  constructor(private service: ApiserviceService, ) { }

  public eserciziList: Esercizi[] = [];


  ngOnInit(): void {
    this.refreshEserciziList();

  }




  refreshEserciziList() {
    this.service.getEserciziList().subscribe(data => {
      this.eserciziList = data;
    });
  }



}
