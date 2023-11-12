import { Injectable } from '@angular/core';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class JWTService {

    jwtToken: string = "";
    decodedToken: { [key: string]: string } = {};

    constructor() {
    }

    setToken(token: string) {
      if (token) {
        this.jwtToken = token;
      }
    }

    decodeToken() {
      if (this.jwtToken) {
      this.decodedToken = jwt_decode.jwtDecode(this.jwtToken);
      }
    }

    getDecodeToken() {
      return jwt_decode.jwtDecode(this.jwtToken);      
    }

    getUser() {
      this.decodeToken();
      return this.decodedToken ? this.decodedToken["username"] : null;
    }

    getId() {
      this.decodeToken();
      return this.decodedToken ? this.decodedToken["id"] : null;
    }

    getExpiryTime() {
      this.decodeToken();
      return this.decodedToken ? this.decodedToken["exp"] : null;
    }

    isTokenExpired(): boolean {
      //const expiryTime: number = this.getExpiryTime();
      const expiryTime: number = 0;
      if (expiryTime) {
        return ((1000 * expiryTime) - (new Date()).getTime()) < 5000;
      } else {
        return false;
      }
    }
}
