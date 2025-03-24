import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Esercizi {
  ripetizioni: string;
  distanza: number;
  recupero: number;
  stile: string;
}

@Component({
  selector: 'app-esercizi',
  standalone: false,
  templateUrl: './esercizi.component.html',
  styleUrl: './esercizi.component.css'
})
export class EserciziComponent implements OnInit {

  public esercizi: Esercizi[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
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
