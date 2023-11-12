import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { UserData } from './user-data';

import { LocalstorageService } from './localstorage.service'
import { JWTService } from './jwt.service';
import { LoginResponse } from './login-response';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private exchangeRateUrl = 'https://localhost:7173/api/auth/';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient, private localstorageService: LocalstorageService, private jwtService: JWTService) { 
    }

  login(data: UserData): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.exchangeRateUrl + "login/", data, this.httpOptions)
      .pipe(
        tap(_ => this.log('login success')),
        tap(token => this.saveUserDataToLocalstorage(token.token)),
        catchError(this.handleError<LoginResponse>('deleteExchangeRate', null!))
      );
  }

  register(data: UserData): Observable<UserData> {
    return this.http.post<UserData>(this.exchangeRateUrl + "register/", data, this.httpOptions)
      .pipe(
        tap(_ => this.log('deleted exchange rate')),
        catchError(this.handleError<UserData>('deleteExchangeRate', null!))
      );
  }

  private saveUserDataToLocalstorage(token: string){
    this.jwtService.setToken(token);
    this.localstorageService.set("token", token);
    this.localstorageService.set("userId", this.jwtService.getId()!.toString());
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

  private log(message: string) {
    console.log(`ExchangeRateService: ${message}`);
  }
}
