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

  clonedPiano: { [s: number]: Piani } = {};

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

  deletePiano(piano: Piani) {
    this.service.deletePiano(piano.pianoId).subscribe(() => {
      this.loadPianiLazy(this.lastLazyEvent);
    });
  } 

  onRowEditInit(piano: Piani) {
    console.log('onRowEditInit');
    this.clonedPiano[piano.pianoId] = { ...piano };
  }

  onRowEditSave(piano: Piani) {
    console.log('onRowEditSave');
    piano.username = this.authService.email!;
    this.service.updatePiano(piano).subscribe({
      next: (data) => { console.log('updatePiano next'); },
      error: (err) => { console.log('updatePiano error'); },
      complete: () => { console.log('updatePiano complete'); }
    });
  }

  onRowEditCancel(piano: Piani, index: number) {
    console.log('onRowEditCancel');
    this.clonedPiano[index] = this.clonedPiano[piano.pianoId];
    delete this.clonedPiano[piano.pianoId];
  }
}

