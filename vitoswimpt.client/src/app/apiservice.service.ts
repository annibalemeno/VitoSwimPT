import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Esercizi } from './interfaces/esercizi';

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

  getStili(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl+'/stili');
  }
}


//let headers = new HttpHeaders();
//headers = headers.set('Access-Control-Allow-Origin', '*');
