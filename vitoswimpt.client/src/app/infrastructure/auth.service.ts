import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  readonly apiUrl = 'http://localhost:5194';
  private _token = sessionStorage.getItem('token');
  private _refreshToken = sessionStorage.getItem('refreshToken');
  private _email = sessionStorage.getItem('email');;
  constructor(private http: HttpClient) {
    debugger;
  }

  public get token() {
    return sessionStorage.getItem('token');
  }
  public get refreshToken() {
    return sessionStorage.getItem('refreshToken');
  }
  public get email() {
    return sessionStorage.getItem('email');
  }

  public set token(token: string|null) {
    if (token == null) {
      throw new Error('Assegnazione di token errata');
    }
    this._token = token;
  }

  public set refreshToken(refreshToken: string | null) {
    if (refreshToken == null) {
      throw new Error('Assegnazione di refresh token errata');
    }
    this._refreshToken = refreshToken;
  }

  public set email(email: string | null) {
    if (email == null) {
      throw new Error('Assegnazione di email username token errata');
    }
    this._email = email;
  }

  //#region servizi

  login(credentials: any): Observable<string> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<any>(this.apiUrl + '/users/login', credentials, { headers });
  }

  register(full_credentials: any): Observable<string> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<any>(this.apiUrl + '/users/register', full_credentials, { headers });
  }

  loginWithRefreshToken(): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    let rt = {
      "refreshToken": sessionStorage.getItem('refreshToken')
    }

    return this.http.post<any>(this.apiUrl + '/users/refresh-token', rt, { headers });

  }

  // #endregion

}
