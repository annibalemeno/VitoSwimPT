import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpEvent,
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class authInterceptorInterceptor implements HttpInterceptor { 
  constructor() { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Get the token from localStorage
    const token = sessionStorage.getItem('token');

    // Clone the request and add the token to the headers if it exists
    if (token) {
      const authReq = req.clone({
        setHeaders: { Authorization: `Bearer ${token}` },
      });
      console.log('Interceptor in action on ' + new Date().toLocaleTimeString());
      return next.handle(authReq);
    }
    // If there's no token, just pass the original request
      return next.handle(req);
  };
};





//export const authInterceptorInterceptor2: HttpInterceptorFn = (req, next) => {

//  // Get the token from localStorage
//  const token = localStorage.getItem('token');

//  // Clone the request and add the token to the headers if it exists
//  if (token) {
//    const authReq = req.clone({
//      setHeaders: { Authorization: `Bearer ${token}` },
//    });
//    return next(authReq);
//  }
//  // If there's no token, just pass the original request
//  return next(req);
//};



