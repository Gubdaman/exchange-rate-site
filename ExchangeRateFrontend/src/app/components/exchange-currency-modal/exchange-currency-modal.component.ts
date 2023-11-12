import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CurrencyExchangeRequest } from '../../interfaces/currency-exchange-request';
import { ExchangeRateService } from '../../services/exchange-rate.service';

@Component({
  selector: 'app-exchange-currency-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
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
