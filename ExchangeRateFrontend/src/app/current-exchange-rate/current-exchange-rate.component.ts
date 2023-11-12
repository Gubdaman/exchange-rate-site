import { CommonModule } from '@angular/common';

import { Component, OnInit } from '@angular/core';

import { Observable, Subject } from 'rxjs';

import {
   debounceTime, distinctUntilChanged, switchMap
 } from 'rxjs/operators';

import { CurrentExchangeRate } from '../current-exchange-rate';
import { ExchangeRateService } from '../exchange-rate.service';

@Component({
  selector: 'app-current-exchange-rate',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './current-exchange-rate.component.html',
  styleUrl: './current-exchange-rate.component.css'
})
export class CurrentExchangeRateComponent implements OnInit {
  currentExchangeRates: CurrentExchangeRate[] = [];

  constructor(private exchangeRateService: ExchangeRateService) {}

  ngOnInit(): void {
    this.exchangeRateService.getCurrentExchangeRates()
    .subscribe(exchangeRates => this.currentExchangeRates = exchangeRates);
  }
}
