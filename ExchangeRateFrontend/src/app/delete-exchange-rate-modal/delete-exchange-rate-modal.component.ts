import { CommonModule } from '@angular/common';
import {Component, Inject} from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'app-delete-exchange-rate-modal',
  standalone: true,
  imports: [CommonModule, MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
  templateUrl: './delete-exchange-rate-modal.component.html',
  styleUrl: './delete-exchange-rate-modal.component.css'
})
export class DeleteExchangeRateModalComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteExchangeRateModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: boolean,
  ) {}

  onNoClick(): void {
    this.data = false;
    this.dialogRef.close();
  }
}
