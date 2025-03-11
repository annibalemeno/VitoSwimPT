import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Allenamenti {
  ripetizioni: string;
  distanza: number;
  recupero: number;
  stile: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public allenamenti: Allenamenti[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getAllenamenti();
  }

  getAllenamenti() {
    this.http.get<Allenamenti[]>('/weatherforecast').subscribe(
      (result) => {
        this.allenamenti = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'vitoswimpt.client';
}
