import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Esercizi {
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
  public esercizi: Esercizi[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getAllenamenti();
  }

  getAllenamenti() {
    this.http.get<Esercizi[]>('/esercizi').subscribe(
      (result) => {
        this.esercizi = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'vitoswimpt.client';
}
