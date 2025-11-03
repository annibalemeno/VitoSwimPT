import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpEvent,
  HttpHandlerFn,
} from '@angular/common/http';
import { catchError, finalize, map, Observable, switchMap, throwError } from 'rxjs';
import { ApiserviceService } from '../apiservice.service';

@Injectable()
export class authInterceptor implements HttpInterceptor { 
  constructor(private service: ApiserviceService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    debugger;
    console.log('Interceptor in action on ' + new Date().toLocaleTimeString());
    let token = sessionStorage.getItem('token');
    if (token) {
      return next.handle(this.addToken(req, token)).pipe(
        catchError((error) => {
          if (error.status === 401) {
            console.log('Errore 401');
            return this.handleUnauthorized(req, next);
          }
          return throwError(() => error);
        }),
      );
    }
    else return next.handle(req).pipe(
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
  }

  refreshToken(): Observable<any> {
    debugger;
    console.log('STO REFRESHANDO IL TOKEN')
    const refreshToken = sessionStorage.getItem('refreshToken')!;
    let rt = {
      "refreshToken": refreshToken
    }
    return this.service.loginWithRefreshToken(rt);
  }
};
