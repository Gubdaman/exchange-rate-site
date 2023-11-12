import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { CurrentExchangeRate } from './current-exchange-rate';
import { SavedExchangeRate } from './saved-exchange-rate';

@Injectable({
  providedIn: 'root'
})
export class ExchangeRateService {

  private exchangeRateUrl = 'https://localhost:7173/';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient) { }

    getCurrentExchangeRates(): Observable<CurrentExchangeRate[]> {
      return this.http.get<CurrentExchangeRate[]>(this.exchangeRateUrl + "current-exchange-rates")
        .pipe(
          tap(_ => this.log('fetched current exchange rates')),
          catchError(this.handleError<CurrentExchangeRate[]>('getCurrentExchangeRates', []))
        );
    }

    getSavedExchangeRates(): Observable<SavedExchangeRate[]> {
      return this.http.get<SavedExchangeRate[]>(this.exchangeRateUrl + "saved")
        .pipe(
          tap(_ => this.log('fetched saved exchange rates')),
          catchError(this.handleError<SavedExchangeRate[]>('getCurrentExchangeRates', []))
        );
    }

    saveExchangeRate(rate: SavedExchangeRate): Observable<SavedExchangeRate> {
      return this.http.put<SavedExchangeRate>(this.exchangeRateUrl + "save-exchange-rate", rate)
        .pipe(
          tap(_ => this.log('saved exchange rate')),
          catchError(this.handleError<SavedExchangeRate>('getCurrentExchangeRates', null!))
        );
    }

    deleteExchangeRate(id: number): Observable<boolean> {
      return this.http.delete<boolean>(this.exchangeRateUrl + "delete/" + id)
        .pipe(
          tap(_ => this.log('deleted exchange rate')),
          catchError(this.handleError<boolean>('deleteExchangeRate', false))
        );
    }

    updateExchangeRate(rate: SavedExchangeRate): Observable<SavedExchangeRate> {
      return this.http.post<SavedExchangeRate>(this.exchangeRateUrl + "update-exchange-rate", rate)
        .pipe(
          tap(_ => this.log('deleted exchange rate')),
          catchError(this.handleError<SavedExchangeRate>('deleteExchangeRate', null!))
        );
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
