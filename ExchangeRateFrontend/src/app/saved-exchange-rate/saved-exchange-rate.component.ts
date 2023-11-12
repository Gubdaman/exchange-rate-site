import { CommonModule } from '@angular/common';

import { Component, OnInit } from '@angular/core';

import { Observable, Subject } from 'rxjs';

import {
   debounceTime, distinctUntilChanged, switchMap
 } from 'rxjs/operators';

import { SavedExchangeRate } from '../saved-exchange-rate';
import { ExchangeRateService } from '../exchange-rate.service';

@Component({
  selector: 'app-saved-exchange-rate',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './saved-exchange-rate.component.html',
  styleUrl: './saved-exchange-rate.component.css'
})
export class SavedExchangeRateComponent {
  savedExchangeRates: SavedExchangeRate[] = [];

  constructor(private exchangeRateService: ExchangeRateService) {}

  ngOnInit(): void {
    this.exchangeRateService.getSavedExchangeRates()
    .subscribe(exchangeRates => this.savedExchangeRates = exchangeRates);
  }
}
