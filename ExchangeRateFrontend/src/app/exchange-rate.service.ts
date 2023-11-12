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

  private exchangeRateUrl = 'https://localhost:7173/';  // URL to web api

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

    /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    console.error(`HeroService: ${message}`);
  }
}
