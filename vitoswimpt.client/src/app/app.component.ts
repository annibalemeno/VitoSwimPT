import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  loggedIn: boolean = false;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    debugger;
    let tmp = this.dataService.getData();
    if (sessionStorage.getItem('token') != null) {
      this.loggedIn = true;
    }
  }
  title = 'vitoswimpt.client';
}
