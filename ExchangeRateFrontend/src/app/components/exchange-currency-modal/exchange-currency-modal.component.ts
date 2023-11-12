import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { CurrencyExchangeRequest } from '../../interfaces/currency-exchange-request';
import { ExchangeRateService } from '../../services/exchange-rate.service';

import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'app-exchange-currency-modal',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatDialogModule, ExchangeCurrencyModalComponent],
  templateUrl: './exchange-currency-modal.component.html',
  styleUrl: './exchange-currency-modal.component.css'
})
export class ExchangeCurrencyModalComponent {

  constructor(private exchangeRateService: ExchangeRateService) {}
  
  model: CurrencyExchangeRequest = {
    amount: 0,
    to: "EUR"
  }
  convertedValue: number = 0;

  submitted = false;
  onSubmit() {
    this.exchangeRateService.convertAmount(this.model)
    .subscribe(value => {this.submitted = true; this.convertedValue = value});
  }
}
