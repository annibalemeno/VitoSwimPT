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
  constructor(private accountService: AccountService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    debugger;
    console.log('Interceptor in action on ' + new Date().toLocaleTimeString());
    let token = this.accountService.token;
    if (token) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        },
      });
    }
    return next.handle(req).pipe(
      catchError((error) => {
        if (error.status === 401) {
          console.log('Errore 401');
          return this.accountService.handleUnauthorized(req, next);
        }
        return throwError(() => error);
      }));
  };


//  handleUnauthorized(
//    req: HttpRequest<any>,
//    next: HttpHandler
//  ): Observable<any> {
//    debugger;
///*    return this.refreshToken().pipe(*/
//    return this.accountService.loginWithRefreshToken().pipe(
//      switchMap((newToken: any) => {
//        debugger;
//        if (newToken) {
//          console.log("New Access Token generated: ", newToken.accessToken.toString())
//          // Retry the original request with the new token
//          sessionStorage.setItem('refreshToken', newToken.refreshToken);
//          return next.handle(this.addToken(req, newToken.accessToken));
//        }

//        // If token refresh fails, log out the user
//        this.logout();
//        return throwError(() => 'Token expired');
//      }),
//      catchError((error) => {
//        this.logout(); // Log out on error
//        return throwError(() => error);
//      }),
//      finalize(() => {
//      }),
//    );
//  }

  logout() {
    //sessionStorage.clear();
    console.log('logout from authInterceptor');
    debugger;
    return this.accountService.logout();
  }

}

//refreshToken() {
//  debugger;
//  console.log('i am refreshing the token')
//  //const refreshToken = sessionStorage.getItem('refreshToken')!;
//  //let rt = {
//  //  "refreshToken": refreshToken
//  //}
//  this.accountService.loginWithRefreshToken();
//}
