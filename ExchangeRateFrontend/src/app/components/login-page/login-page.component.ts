import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserData } from '../../interfaces/user-data';
import { AuthenticationService } from '../../services/authentication.service';

import {MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { SavedExchangeRate } from '../../interfaces/saved-exchange-rate';
import { LocalstorageService } from '../../services/localstorage.service';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [CommonModule, MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {
  data: UserData = {
    password: "",
    username: "",
    id: 0
  };

  constructor(private authService: AuthenticationService, private localstorageService: LocalstorageService) {}

  login(): void {
    this.authService.login(this.data)
    .subscribe(_ => window.alert("Login was successful!"));
  }

  register(): void {
    this.authService.register(this.data)
    .subscribe(_ => window.alert("Registration was successful!"));
  }

  logout(): void {
    this.localstorageService.set('token', '');
    this.localstorageService.set('userId', '');
  }
}
