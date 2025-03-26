import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Esercizi {
  ripetizioni: string;
  distanza: number;
  recupero: number;
  stile: string;
}

@Component({
  selector: 'app-show-esercizi',
  standalone: false,
  templateUrl: './show-esercizi.component.html',
  styleUrl: './show-esercizi.component.css'
})
export class ShowEserciziComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public esercizi: Esercizi[] = [];

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
}
