import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import {MatButtonModule} from '@angular/material/button';
import { AuthenticationService } from './services/authentication.service';
import { LocalstorageService } from './services/localstorage.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HttpClientModule, MatButtonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  currentUsername: string = "Vendég";

  constructor(private authService: AuthenticationService, private localstorageService: LocalstorageService) { }

  ngOnInit() {
    this.authService.currentUsername.subscribe(currentUsername => this.currentUsername = currentUsername);
    this.currentUsername = this.localstorageService.get('userName') || "Vendég";
  }
}
