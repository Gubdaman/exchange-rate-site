import { CommonModule } from '@angular/common';

import { Component, OnInit } from '@angular/core';

import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

import { CurrentExchangeRate } from '../current-exchange-rate';
import { SavedExchangeRate } from '../saved-exchange-rate';
import { ExchangeRateService } from '../exchange-rate.service';
import { SaveExchangeModalComponent } from '../save-exchange-modal/save-exchange-modal.component';

@Component({
  selector: 'app-current-exchange-rate',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatDialogModule],
  templateUrl: './current-exchange-rate.component.html',
  styleUrl: './current-exchange-rate.component.css'
})
export class CurrentExchangeRateComponent implements OnInit {
  currentExchangeRates: CurrentExchangeRate[] = [];

  constructor(private exchangeRateService: ExchangeRateService, public dialog: MatDialog) {}

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
      id: 0
    }
    this.exchangeRateService.saveExchangeRate(req)
    .subscribe(exchangeRates => window.alert("Save was successful!"));
  }

  openDialog(exchangeRateData: CurrentExchangeRate): void {
    const dialogRef = this.dialog.open(SaveExchangeModalComponent, {
      data: "",
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined){
        this.saveExchangeRate(exchangeRateData, result);
      }
    });
  }
}
