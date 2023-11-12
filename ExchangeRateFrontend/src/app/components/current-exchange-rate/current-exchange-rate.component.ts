import { CommonModule } from '@angular/common';
import {MatTableModule} from '@angular/material/table';

import { Component, OnInit } from '@angular/core';

import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';

import { CurrentExchangeRate } from '../../interfaces/current-exchange-rate';
import { SavedExchangeRate } from '../../interfaces/saved-exchange-rate';
import { ExchangeRateService } from '../../services/exchange-rate.service';
import { SaveExchangeModalComponent } from '../save-exchange-modal/save-exchange-modal.component';
import { ExchangeCurrencyModalComponent } from '../exchange-currency-modal/exchange-currency-modal.component';
import { LocalstorageService } from '../../services/localstorage.service';

@Component({
  selector: 'app-current-exchange-rate',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatDialogModule, ExchangeCurrencyModalComponent, MatTableModule, MatSnackBarModule],
  templateUrl: './current-exchange-rate.component.html',
  styleUrl: './current-exchange-rate.component.css'
})
export class CurrentExchangeRateComponent implements OnInit {
  displayedColumns: string[] = ['currency', 'value', 'save'];
  currentExchangeRates: CurrentExchangeRate[] = [];

  constructor(private exchangeRateService: ExchangeRateService, public dialog: MatDialog, private localstorageService: LocalstorageService, private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.exchangeRateService.getCurrentExchangeRates()
    .subscribe(exchangeRates => this.currentExchangeRates = exchangeRates);
  }

  saveExchangeRate(exchangeRateData: CurrentExchangeRate, comment: string): void {
    const req: SavedExchangeRate = {
      comment: comment,
      currency: exchangeRateData.currency,
      exchangeRate: exchangeRateData.value,
      createdAt: "",
      id: 0,
      userId: +(this.localstorageService.get('userId') || 0)
    }
    this.exchangeRateService.saveExchangeRate(req)
    .subscribe(exchangeRates => this._snackBar.open("Sikeres mentés!", "Bezár"));
  }

  openDialog(exchangeRateData: CurrentExchangeRate): void {
    const dialogRef = this.dialog.open(SaveExchangeModalComponent, {
      data: "",
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined){
        this.saveExchangeRate(exchangeRateData, result);
      }
    });
  }
}
