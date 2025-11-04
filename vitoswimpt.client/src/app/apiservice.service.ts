import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Esercizi } from './interfaces/esercizi';
import { Stili } from './interfaces/stili';
import { Allenamenti } from './interfaces/allenamenti';
import { EserciziAllenamento } from './interfaces/eserciziallenamento';
import { Piani } from './interfaces/piani';
import { PianiAllenamento } from './interfaces/pianiallenamento';

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
    //let headers = new HttpHeaders();
    //headers = headers.set('Content-Type', 'application/json; charset=utf-8').set('Authorization', `Bearer ${auth_token}`);
    let headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8' });
    return this.http.get<Allenamenti[]>(this.apiUrl + '/allenamenti', { headers });
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

  getEserciziAllenamentoList(): Observable<EserciziAllenamento[]> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.get<EserciziAllenamento[]>(this.apiUrl + '/eserciziallenamenti', { headers });
  }

  //#endregion

  //#region Piani
  getPianiList(): Observable<Piani[]> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.get<Piani[]>(this.apiUrl + '/piani', { headers });
  }

  getPianiByUser(email: string): Observable<Piani[]> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.get<Piani[]>(this.apiUrl + '/piani/getPianiByUser?email=' + email, { headers });
  }
  //

  addPiano(piano: Piani): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<Piani[]>(this.apiUrl + '/piani', piano, { headers });
  }

  updatePiano(piano: Piani): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.put<Piani[]>(this.apiUrl + '/piani/UpdatePiano/', piano, { headers });
  }

  deletePiano(pianoId: number): Observable<number> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.delete<number>(this.apiUrl + '/piani/' + pianoId, { headers });
  }


  //#endregion Piano

  //#region PianiAllenamento
  getPianoAllenamento(pianoId: number): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.get<PianiAllenamento>(this.apiUrl + '/pianiallenamento/' + pianoId, { headers });
  }

  associaPianoAllenamento(pianoId: number, allenamentoId: number): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    var urlchiamata = this.apiUrl + '/eserciziallenamenti/' + pianoId + '/' + allenamentoId;
    console.log('Urlchiamata = ', urlchiamata);
    return this.http.post<Allenamenti[]>(this.apiUrl + '/pianiallenamento/' + pianoId + '/' + allenamentoId, { headers });
  }

  disassociaAllenamentoPiano(pianoId: number, allenamentoId: number): Observable<number> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.delete<number>(this.apiUrl + '/pianiallenamento/' + pianoId + '/' + allenamentoId, { headers });
  }

  getAllenamentiAssociabiliPiano(pianoId: number): Observable<any[]> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.get<Allenamenti[]>(this.apiUrl + '/pianiallenamento/Associabili/' + pianoId, { headers });
  }
   

  //#endregion PianiAllenamento
}





//let headers = new HttpHeaders();
//headers = headers.set('Access-Control-Allow-Origin', '*');
