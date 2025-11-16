import { HttpClient, HttpHandler, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  readonly apiUrl = 'http://localhost:5194';
  private _token = sessionStorage.getItem('token');
  private _refreshToken = sessionStorage.getItem('refreshToken');
  private _email = sessionStorage.getItem('email');

  private tokenSubject: BehaviorSubject<string | null>;
  public tokenOb: Observable<string | null>;

  constructor(private http: HttpClient) {
    /*this.tokenSubject = new BehaviorSubject(JSON.parse(sessionStorage.getItem('token')!));*/
    this.tokenSubject = new BehaviorSubject(sessionStorage.getItem('token'));
    this.tokenOb = this.tokenSubject.asObservable();
  }

  public get token() {
    return this.tokenSubject.value;
  }

  //public get token() {
  //  return sessionStorage.getItem('token');
  //}
  public get refreshToken() {
    return sessionStorage.getItem('refreshToken');
  }
  public get email() {
    return sessionStorage.getItem('email');
  }

  public set token(token: string | null) {
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
    debugger;
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    /*return this.http.post<any>(this.apiUrl + '/users/login', credentials, { headers });*/
    return this.http.post<any>(this.apiUrl + '/users/login', credentials, { headers }).pipe(map(data => {
      let token = data.accessToken;
      let refreshToken = data.refreshToken;
      console.log('data in account service login: ' + data.toString());
      this.tokenSubject.next(token);
      return data;
    }
    ));
  }


  register(full_credentials: any): Observable<string> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post<any>(this.apiUrl + '/users/register', full_credentials, { headers });
  }

  loginWithRefreshToken():Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    let rt = {
      "refreshToken": sessionStorage.getItem('refreshToken')
    }
    return this.http.post<any>(this.apiUrl + '/users/refresh-token', rt, { headers });
  }

  logout() {
    debugger;
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    /* let userId = '4914C4FC-9A68-4168-88B0-2DB780D6F4FC';*/
    let email = this.email;
    //remove all refresh token for the current user
    this.http.delete<any>(this.apiUrl + '/users/' + email, { headers }).subscribe(() => {
      debugger;
      console.log('logout ok');
      sessionStorage.clear();
      this.tokenSubject.next(null);
      /* sessionStorage.removeItem('');*/
      if (window.location.href.indexOf('login') !== -1) {
        window.location.reload();
      } else {
        /* this.router.navigate(['']);*/
        window.location.href = '';
      }
    },
      error => {
        console.log('errore in logout');
      });
  }

  addToken(request: HttpRequest<any>, token: string): HttpRequest<any> {
    debugger;
    console.log('AddToken' + token);
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      },
    });
  }

  handleUnauthorized(
    req: HttpRequest<any>, next: HttpHandler): Observable<any> {
    /*    return this.refreshToken().pipe(*/
    console.log("handleUnauthorized");
    this.tokenSubject.next(null);
    this.loginWithRefreshToken().subscribe({
      next: (data: any) => {
        let token = data.accessToken;
        this.tokenSubject.next(token);
        sessionStorage.setItem('refreshToken', data.refreshToken);
        if (this.token) {
          console.log("New Access Token generated: ", this.token.toString());
          // Retry the original request with the new token
          return next.handle(this.addToken(req, this.token));
        }
        else {
          //  // If token refresh fails, log out the user
            this.logout();
            return throwError(() => 'Token expired');
          }
      },
      error: () => { console.log('errore in refresh token'); }
    });

    return throwError(() => 'handleUnauthorized fail');

  }
}
  //#endregion


