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
  first:number = 0;
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
    console.log('page change with first= ' + this.first + ' , rows= ' + this.rows);
  }

  loadEserciziLazy(event: any) {
    debugger;
    /* this.loading = true;*/
    this.first = event.first;
    this.rows = event.rows;
    const page = event.first / event.rows;
    const size = event.rows;
    var filtri = event.filters;
    filtri.skip = page * size;
    filtri.take = size;
    //this.service.getEserciziList(page*size, size, event.filters).subscribe((res: any) => {
    this.service.getEserciziList(filtri).subscribe(data => {
      debugger;
      this.eserciziList = data.data;
      this.totalRecords = data.totalRecords;
      });

      //this.products = res.data;
      //this.totalRecords = res.total;
      /*this.totalRecords = data.length;  */
      /*this.loading = false;*/

    //this.eserciziList = res.data;
    //this.totalRecords = res.totalRecords;

/*    });*/
  }

  isLastPage(): boolean {
    return this.eserciziList ? this.first + this.rows >= this.totalRecords : true;
  }

  isFirstPage(): boolean {
    return this.eserciziList ? this.first === 0 : true;
  }

}
