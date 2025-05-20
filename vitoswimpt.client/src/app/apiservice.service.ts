import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Esercizi } from './interfaces/esercizi';
import { Stili } from './interfaces/stili';
import { Allenamenti } from './interfaces/allenamenti';
import { EserciziAllenamento } from './interfaces/eserciziallenamento';
import { Piani } from './interfaces/piani';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  readonly apiUrl = 'http://localhost:5194';


  constructor(private http: HttpClient) { }

  // #region Esercizi

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
    return this.http.delete<number>('/esercizi/' + esercizioId, { headers });
  }

  updateEsercizio(esercizio: Esercizi): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.put<Esercizi[]>('/esercizi/UpdateEsercizi/', esercizio, { headers });
  }

  // #endregion

  getStili(): Observable<Stili[]> {
    return this.http.get<Stili[]>(this.apiUrl+'/stili');
  }

  // #region Allenamenti

  getAllenamentiList(): Observable<Allenamenti[]> {
    return this.http.get<Allenamenti[]>(this.apiUrl + '/allenamenti');
  }

  addAllenamento(training: Allenamenti): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<Allenamenti[]>(this.apiUrl + '/allenamenti', training, { headers });
  }

  deleteAllenamento(allenamentoId: number): Observable<number> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.delete<number>(this.apiUrl +'/allenamenti/' + allenamentoId, { headers });
  }

  updateAllenamento(training: Allenamenti): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.put<Allenamenti[]>(this.apiUrl+'/allenamenti/UpdateAllenamenti/', training, { headers });
  }

  // #endregion

  // #region EserciziAllenamento
  getEsercizioAllenamento(esercizioAllenamentoId: number): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.get<EserciziAllenamento>(this.apiUrl + '/eserciziallenamenti/' + esercizioAllenamentoId, { headers });
  }

  getEserciziAssociabiliAllenamento(allenamentoId: number): Observable<any[]> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.get<Esercizi[]>(this.apiUrl + '/eserciziallenamenti/Associabili/' + allenamentoId, { headers });
  }

  disassociaEsercizioAllenamento(allenamentoId: number, esercizioId:number): Observable<number> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.delete<number>(this.apiUrl + '/eserciziallenamenti/' + allenamentoId+'/'+esercizioId, { headers });
  }

  associaEsercizioAllenamento(allenamentoId: number, esercizioId: number): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    var urlchiamata = this.apiUrl + '/eserciziallenamenti/' + allenamentoId + '/' + esercizioId;
    console.log('Urlchiamata = ', urlchiamata);
    return this.http.post<Allenamenti[]>(this.apiUrl + '/eserciziallenamenti/' + allenamentoId + '/' + esercizioId, { headers });
  }

  //getEserciziAllenamentoList(): Observable<EserciziAllenamento[]> {
  //  return this.http.get<EserciziAllenamento[]>(this.apiUrl + '/eserciziallenamenti');
  //}

  //#endregion

  //#region Piani
  getPianiList(): Observable<Piani[]> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.get<Piani[]>(this.apiUrl + '/piani', { headers });
  }
  //#endregion Piani

  //#region PianiAllenamento

  //#endregion PianiAllenamento
}





//let headers = new HttpHeaders();
//headers = headers.set('Access-Control-Allow-Origin', '*');
