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

  sortField = 'pianoId';
  sortOrder = 1;

  public PianiList: Piani[] = [];
  totalRecords: number = 0;

  displayDialog = false;
  newItem: any = {};
  lastLazyEvent: any;

  ngOnInit(): void {
    }


  loadPianiLazy(event: any) {
    this.lastLazyEvent = event; 
    const sortField = event.sortField ?? this.sortField;
    const sortOrder = event.sortOrder ?? this.sortOrder;

    this.sortField = sortField;
    this.sortOrder = sortOrder;

    var filtri = event.filters;
    filtri.skip = 0;
    filtri.take = 20;
    filtri.globalfilter = "";
    filtri.sortField = event.sortField ?? this.sortField;
    filtri.sortOrder = event.sortOrder ?? this.sortOrder;

    if (this.authService.email != null) {
      filtri.usermail = this.authService.email;
      this.service.getPianiByUser(filtri).subscribe(data => {
        this.PianiList = data.data;
        this.totalRecords = data.totalRecords;
      });
    }
  }

  openNew() {
    this.newItem = {};
    this.displayDialog = true;
  }

  save() {
    this.newItem.pianoId = 0;
    this.newItem.username = this.authService.email!;
    this.service.addPiano(this.newItem).subscribe(data => {
      this.displayDialog = false;
      this.loadPianiLazy(this.lastLazyEvent);
    });
  }

}

