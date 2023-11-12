import { CommonModule } from '@angular/common';
import {Component, Inject} from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { SavedExchangeRate } from '../saved-exchange-rate';

@Component({
  selector: 'app-edit-exchange-rate-modal',
  standalone: true,
  imports: [CommonModule, MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
  templateUrl: './edit-exchange-rate-modal.component.html',
  styleUrl: './edit-exchange-rate-modal.component.css'
})
export class EditExchangeRateModalComponent {
  constructor(
    public dialogRef: MatDialogRef<EditExchangeRateModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SavedExchangeRate,
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
