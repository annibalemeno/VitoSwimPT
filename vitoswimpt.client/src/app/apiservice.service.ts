import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Esercizi } from './interfaces/esercizi';
import { Stili } from './interfaces/stili';
import { Allenamenti } from './interfaces/allenamenti';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  readonly apiUrl = 'http://localhost:5194';


  constructor(private http: HttpClient) { }

  getEserciziList(): Observable<Esercizi[]> {
    return this.http.get<Esercizi[]>('/esercizi');
  }

  addEsercizio(esercizio: Esercizi): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<Esercizi[]>('/esercizi', esercizio, { headers });
  }

  deleteEsercizio(esercizioId: number): Observable<number> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.delete<number>('/esercizi/DeleteEsercizi/' + esercizioId, { headers });
  }

  updateEsercizio(esercizio: Esercizi): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.put<Esercizi[]>('/esercizi/UpdateEsercizi/', esercizio, { headers });
  }

  getStili(): Observable<Stili[]> {
    return this.http.get<Stili[]>(this.apiUrl+'/stili');
  }

  getAllenamentiList(): Observable<Allenamenti[]> {
    return this.http.get<Allenamenti[]>(this.apiUrl + '/allenamenti');
  }

  addAllenamento(train: Allenamenti): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<Allenamenti[]>('/Allenamenti', train, { headers });
  }
}




//let headers = new HttpHeaders();
//headers = headers.set('Access-Control-Allow-Origin', '*');
