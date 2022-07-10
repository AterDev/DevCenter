import { Component, OnInit } from '@angular/core';
// import { OAuthService, OAuthErrorEvent, UserInfo } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { UntypedFormGroup, UntypedFormControl, Validators, FormGroup, FormControl } from '@angular/forms';
import { AuthService } from 'src/app/share/services/auth.service';
import { LoginService } from 'src/app/auth/login.service';
import { LoginDto } from 'src/app/share/models/auth/login-dto.model';
import { ResourceService } from 'src/app/share/services/resource.service';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm!: FormGroup;
  loginDto: LoginDto;
  constructor(
    private authService: AuthService,
    private loginService: LoginService,
    private resourceSrv: ResourceService,
    private router: Router
  ) {
    this.loginDto = {
      userName: '',
      password: ''
    };
  }
  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(20)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(50)])
    });
  }


  /**
   * 错误信息
   * @param type 字段名称
   */
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'username':
        return this.username?.errors?.['required'] ? '用户名必填' :
          this.username?.errors?.['minlength']
            || this.username?.errors?.['maxlength'] ? '用户名长度4-20位' : '';
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
    let data = this.loginForm.value as LoginDto;
    this.authService.login(data)
      .subscribe(res => {
        this.loginService.isLogin = true;
        this.loginService.saveLoginState(res);
        this.getResources().then(() => {
          this.router.navigate(['/'])
        });

      });
  }

  async getResources(): Promise<void> {
    let res = await lastValueFrom(this.resourceSrv.getAllResources());
    localStorage.setItem('searchResources', JSON.stringify(res));
  }
  logout(): void {
    this.loginService.logout();
  }
}
