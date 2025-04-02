import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Esercizi } from './interfaces/esercizi';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {

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
}
