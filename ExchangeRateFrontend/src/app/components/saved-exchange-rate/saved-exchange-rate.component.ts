import { CommonModule } from '@angular/common';

import { Component, OnInit } from '@angular/core';

import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTableModule} from '@angular/material/table';

import { SavedExchangeRate } from '../../interfaces/saved-exchange-rate';
import { ExchangeRateService } from '../../services/exchange-rate.service';
import { EditExchangeRateModalComponent } from '../edit-exchange-rate-modal/edit-exchange-rate-modal.component';
import { DeleteExchangeRateModalComponent } from '../delete-exchange-rate-modal/delete-exchange-rate-modal.component';

@Component({
  selector: 'app-saved-exchange-rate',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatDialogModule, MatTableModule],
  templateUrl: './saved-exchange-rate.component.html',
  styleUrl: './saved-exchange-rate.component.css'
})
export class SavedExchangeRateComponent {
  displayedColumns: string[] = ['currency', 'value', 'comment', 'createdAt', 'edit', 'delete'];
  savedExchangeRates: SavedExchangeRate[] = [];

  constructor(private exchangeRateService: ExchangeRateService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.exchangeRateService.getSavedExchangeRates()
    .subscribe(exchangeRates => this.savedExchangeRates = exchangeRates);
  }

  openEditDialog(exchangeRateData: SavedExchangeRate): void {
    const dialogRef = this.dialog.open(EditExchangeRateModalComponent, {
      data: exchangeRateData,
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined){
        this.exchangeRateService.updateExchangeRate(exchangeRateData)
          .subscribe(exchangeRates => window.alert("Update was successful!"));
      }
    });
  }

  openDeleteDialog(exchangeRateData: SavedExchangeRate): void {
    const dialogRef = this.dialog.open(DeleteExchangeRateModalComponent, {
      data: true,
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if(result === true){
        this.exchangeRateService.deleteExchangeRate(exchangeRateData.id)
          .subscribe(exchangeRates => window.alert("Delete was successful!"));
      }
    });
  }
}
