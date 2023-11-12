import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserData } from '../../interfaces/user-data';
import { AuthenticationService } from '../../services/authentication.service';

import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { LocalstorageService } from '../../services/localstorage.service';
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [CommonModule, MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatSnackBarModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {
  data: UserData = {
    password: "",
    username: "",
    id: 0
  };

  constructor(private authService: AuthenticationService, private localstorageService: LocalstorageService, private _snackBar: MatSnackBar) {}

  login(): void {
    this.authService.login(this.data)
    .subscribe(_ => this._snackBar.open("Sikeres bejelentkezés!", "Bezár"));
  }

  register(): void {
    this.authService.register(this.data)
    .subscribe(_ => this._snackBar.open("Sikeres regisztráció!", "Bezár"));
  }

  logout(): void {
    this.localstorageService.set('token', '');
    this.localstorageService.set('userId', '');
    this.localstorageService.set('userName', '');
    this._snackBar.open("Sikeres kijelentkezés!", "Bezár")
  }
}
