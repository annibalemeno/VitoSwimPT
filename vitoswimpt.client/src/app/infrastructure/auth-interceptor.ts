import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpEvent,
} from '@angular/common/http';
import { catchError, finalize, Observable, switchMap, throwError } from 'rxjs';
import { AccountService } from './account.service';

@Injectable()
export class authInterceptor implements HttpInterceptor { 
  constructor(private authService: AccountService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    debugger;
    console.log('Interceptor in action on ' + new Date().toLocaleTimeString());
    let token = this.authService.token;
    if (token) {
      req = this.addToken(req, token);
    }
    return next.handle(req).pipe(
      catchError((error) => {
        if (error.status === 401) {
          console.log('Errore 401');
          return this.handleUnauthorized(req, next);
        }
        return throwError(() => error);
      }));
  };


  handleUnauthorized(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<any> {
    debugger;
    return this.refreshToken().pipe(
      switchMap((newToken: any) => {
        debugger;
        if (newToken) {
          // Retry the original request with the new token
          sessionStorage.setItem('refreshToken', newToken.refreshToken);
          return next.handle(this.addToken(req, newToken.accessToken));
        }

        // If token refresh fails, log out the user
        this.logout();
        return throwError(() => 'Token expired');
      }),
      catchError((error) => {
        this.logout(); // Log out on error
        return throwError(() => error);
      }),
      finalize(() => {
      }),
    );
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

  logout() {
    //sessionStorage.clear();
    console.log('logout from authInterceptor');
    debugger;
    return this.authService.logout();
  }

  refreshToken(): Observable<any> {
    debugger;
    console.log('i am refreshing the token')
    //const refreshToken = sessionStorage.getItem('refreshToken')!;
    //let rt = {
    //  "refreshToken": refreshToken
    //}
    return this.authService.loginWithRefreshToken();
  }
};
