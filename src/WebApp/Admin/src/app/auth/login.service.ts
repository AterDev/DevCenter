import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class LoginService {
    isLogin = false;
    userName?: string | null = null;
    constructor() {
    }

    authorize(): void {}

    logout(): void{}
}
