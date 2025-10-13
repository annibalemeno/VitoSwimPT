import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private logged = new Subject();

  constructor() { }

  getData() {
    return this.logged;
  }

  updateData(data: boolean) {
    this.logged.next(data);
  }
}
