import { Component, Input, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEvent } from '@angular/common/http';
import { Esercizi } from '../../../interfaces/esercizi';

@Component({
  selector: 'app-add-edit-esercizi',
  standalone: false,
  templateUrl: './add-edit-esercizi.component.html',
  styleUrl: './add-edit-esercizi.component.css'
})
export class AddEditEserciziComponent implements OnInit {
  constructor(private http: HttpClient) { }

  @Input() eserc: any;
  EsercizioId = "";
  Ripetizioni = "";
  Distanza = "";
  Recupero = "";
  Stile = "";

  ngOnInit(): void {
    this.EsercizioId = this.eserc.esercizioId;
    this.Ripetizioni = this.eserc.ripetizioni;
    this.Distanza = this.eserc.distanza;
    this.Recupero = this.eserc.recupero;
    this.Stile = this.eserc.stile;
  }

  addEsercizio() {
    debugger;
    console.log("addEsercizio");
    var esercizio = {
      ripetizioni: this.Ripetizioni,
      distanza: this.Distanza,
      recupero: this.Recupero,
      stile: this.Stile
    };

    //'responseType': 'text'  'application/json'
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    this.http.post<Esercizi[]>('/esercizi', esercizio, { headers }).subscribe(data => {
      alert(data.toString());
    });
  };
  updateEsercizio() {
    console.log("updateEserczio");
    var esercizio = {
      esercizioId: this.EsercizioId,
      ripetizioni: this.Ripetizioni,
      distanza: this.Distanza,
      recupero: this.Recupero,
      stile: this.Stile
    };

    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    this.http.put<Esercizi[]>('/esercizi/UpdateEsercizi/', esercizio,{ headers }).subscribe(data => {
      //alert('update ok');
      alert(data.toString());
    });
  };

}
