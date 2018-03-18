import { CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private jwtHelper: JwtHelperService) {}

  canActivate() {
    return !this.jwtHelper.isTokenExpired();
  }
}

@Injectable()
export class NonauthGuard implements CanActivate {
  canActivate() {
    return true;
  }
}
