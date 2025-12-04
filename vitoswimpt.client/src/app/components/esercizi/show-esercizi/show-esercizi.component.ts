import { Component, OnInit } from '@angular/core';
import { Esercizi } from '../../../interfaces/esercizi';
import { ApiserviceService } from '../../../apiservice.service';
import { FilterItem } from '../../../interfaces/filter';

@Component({
  selector: 'app-show-esercizi',
  standalone: false,
  templateUrl: './show-esercizi.component.html',
  styleUrl: './show-esercizi.component.css'
})
export class ShowEserciziComponent implements OnInit {

  stiliList: FilterItem[] = [];
  public eserciziList: Esercizi[] = [];
  first = 0;
  rows = 10;
  totalRecords:number = 0;


  constructor(private service: ApiserviceService, ) { }


  ngOnInit(): void {
    //this.refreshEserciziList();

    this.service.getStili().subscribe(data => {
        data.forEach(x => {
          this.stiliList.push({ label: x.nome, value: x.nome });
        });
    });
  }

  //refreshEserciziList() {
  //  this.service.getEserciziList(1,8).subscribe(data => {
  //    this.eserciziList = data;
  //  });
  //}

  next() {
    this.first = this.first + this.rows;
    console.log('Next');
  }

  prev() {
    this.first = this.first - this.rows;
    console.log('Prev');
  }

  reset() {
    this.first = 0;
    console.log('Reset');
  }

  pageChange(event: any) {
    debugger;
    this.first = event.first;
    this.rows = event.rows;
  }

  loadEserciziLazy(event: any) {
    debugger;
   /* this.loading = true;*/
    const page = event.first / event.rows;
    const size = event.rows;
    this.service.getEserciziList(page*size, size).subscribe((data: any) => {
      //this.products = res.data;
      //this.totalRecords = res.total;
      this.eserciziList = data;
      /*this.totalRecords = data.length;  */
      this.totalRecords = 100;  
      /*this.loading = false;*/
    });
  }

  isLastPage(): boolean {
    return this.eserciziList ? this.first + this.rows >= this.eserciziList.length : true;
  }

  isFirstPage(): boolean {
    return this.eserciziList ? this.first === 0 : true;
  }

}
