import { Routes } from '@angular/router';
import {LoginPageComponent} from './login-page/login-page.component';
import {CurrentExchangeRateComponent} from './current-exchange-rate/current-exchange-rate.component';
import {SavedExchangeRateComponent} from './saved-exchange-rate/saved-exchange-rate.component';

export const routes: Routes = [
    { path: 'login', component: LoginPageComponent },
    { path: 'current', component: CurrentExchangeRateComponent },
    { path: 'saved', component: SavedExchangeRateComponent },
];
