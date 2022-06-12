import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class LoginService {
  isLogin = false;
  userName?: string | null = null;
  constructor() {
  }

  saveLoginState(): void {

    this.isLogin = true;
  }

  logout(): void {
    this.isLogin = false;
  }
}
