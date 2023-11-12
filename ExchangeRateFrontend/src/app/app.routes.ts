import { Routes } from '@angular/router';
import {LoginPageComponent} from './components/login-page/login-page.component';
import {CurrentExchangeRateComponent} from './components/current-exchange-rate/current-exchange-rate.component';
import {SavedExchangeRateComponent} from './components/saved-exchange-rate/saved-exchange-rate.component';

export const routes: Routes = [
    { path: 'login', component: LoginPageComponent },
    { path: 'current', component: CurrentExchangeRateComponent },
    { path: 'saved', component: SavedExchangeRateComponent },
];
