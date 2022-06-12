import { Component, OnInit } from '@angular/core';
// import { OAuthService, OAuthErrorEvent, UserInfo } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms';
import { AuthService } from 'src/app/share/services/auth.service';
import { LoginService } from 'src/app/auth/login.service';
import { LoginDto } from 'src/app/share/models/auth/login-dto.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm!: UntypedFormGroup; constructor(
    private authService: AuthService,
    private loginService: LoginService,
    private router: Router

  ) {
  }
  get email() { return this.loginForm.get('email'); }
  get password() { return this.loginForm.get('password'); }
  ngOnInit(): void {
    this.loginForm = new UntypedFormGroup({
      email: new UntypedFormControl('', [Validators.required, Validators.email]),
      password: new UntypedFormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(50)])
    });
  }


  /**
   * 错误信息
   * @param type 字段名称
   */
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'email':
        return this.email?.errors?.['required'] ? '邮箱必填' :
          this.email?.errors?.['email'] ? '错误的邮箱格式' : '';
      case 'password':
        return this.password?.errors?.['required'] ? '密码必填' :
          this.password?.errors?.['minlength'] ? '密码长度不可低于6位' :
            this.password?.errors?.['maxlength'] ? '密码长度不可超过50' : '';
      default:
        break;
    }
    return '';
  }
  doLogin(): void {
    let data = this.loginForm.value;
    this.authService.login({userName:data.email,password:data.password})
      .subscribe(res => {
        console.log(res);
      });
  }

  logout(): void {

  }

  get userName(): string | null {
    return '';
  }

}
