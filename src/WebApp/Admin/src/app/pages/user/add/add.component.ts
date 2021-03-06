import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/share/services/user.service';
import { User } from 'src/app/share/models/user/user.model';
import { UserAddDto } from 'src/app/share/models/user/user-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { RoleService } from 'src/app/share/services/role.service';
import { lastValueFrom } from 'rxjs';
import { RoleItemDto } from 'src/app/share/models/role/role-item-dto.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  formGroup!: FormGroup;
  data = {} as UserAddDto;
  roles = [] as RoleItemDto[];
  isLoading = true;
  constructor(

    private service: UserService,
    private roleSrv: RoleService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

  get userName() { return this.formGroup.get('userName'); }
  get realName() { return this.formGroup.get('realName'); }
  get position() { return this.formGroup.get('position'); }
  get email() { return this.formGroup.get('email'); }
  get password() { return this.formGroup.get('password'); }
  get phoneNumber() { return this.formGroup.get('phoneNumber'); }
  get avatar() { return this.formGroup.get('avatar'); }
  get roleIds() { return this.formGroup.get('roleIds'); }


  ngOnInit(): void {
    this.initForm();
    this.getRoles();
  }

  async getRoles() {
    let res = await lastValueFrom(this.roleSrv.filter({ pageIndex: 1, pageSize: 20 }));
    if (res) {
      this.roles = res.data!;
      this.isLoading = false;
    }
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      userName: new FormControl(null, [Validators.required, Validators.maxLength(30)]),
      roleIds: new FormControl(null, [Validators.required]),
      realName: new FormControl(null, [Validators.maxLength(30)]),
      position: new FormControl(null, [Validators.maxLength(30)]),
      email: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      password: new FormControl(null, [Validators.maxLength(100)]),
      phoneNumber: new FormControl(null, [Validators.maxLength(20)]),
      avatar: new FormControl(null, [Validators.maxLength(200)]),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'userName':
        return this.userName?.errors?.['required'] ? 'UserName??????' :
          this.userName?.errors?.['minlength'] ? 'UserName???????????????' :
            this.userName?.errors?.['maxlength'] ? 'UserName????????????30???' : '';
      case 'roleIds':
        return this.userName?.errors?.['required'] ? '??????????????????' : '';
      case 'realName':
        return this.realName?.errors?.['required'] ? 'RealName??????' :
          this.realName?.errors?.['minlength'] ? 'RealName???????????????' :
            this.realName?.errors?.['maxlength'] ? 'RealName????????????30???' : '';
      case 'position':
        return this.position?.errors?.['required'] ? 'Position??????' :
          this.position?.errors?.['minlength'] ? 'Position???????????????' :
            this.position?.errors?.['maxlength'] ? 'Position????????????30???' : '';
      case 'email':
        return this.email?.errors?.['required'] ? 'Email??????' :
          this.email?.errors?.['minlength'] ? 'Email???????????????' :
            this.email?.errors?.['maxlength'] ? 'Email????????????100???' : '';
      case 'password':
        return this.password?.errors?.['required'] ? 'Password??????' :
          this.password?.errors?.['minlength'] ? 'Password???????????????' :
            this.password?.errors?.['maxlength'] ? 'Password????????????100???' : '';
      case 'phoneNumber':
        return this.phoneNumber?.errors?.['required'] ? 'PhoneNumber??????' :
          this.phoneNumber?.errors?.['minlength'] ? 'PhoneNumber???????????????' :
            this.phoneNumber?.errors?.['maxlength'] ? 'PhoneNumber????????????20???' : '';
      case 'avatar':
        return this.avatar?.errors?.['required'] ? 'Avatar??????' :
          this.avatar?.errors?.['minlength'] ? 'Avatar???????????????' :
            this.avatar?.errors?.['maxlength'] ? 'Avatar????????????200???' : '';

      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as UserAddDto;
      this.data = { ...data, ...this.data };
      this.service.add(this.data)
        .subscribe(res => {
          this.snb.open('????????????');
          // this.dialogRef.close(res);
          this.router.navigate(['../index'], { relativeTo: this.route });
        });
    }
  }
  back(): void {
    this.location.back();
  }
}
