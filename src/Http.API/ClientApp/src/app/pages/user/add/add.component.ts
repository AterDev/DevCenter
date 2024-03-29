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
        return this.userName?.errors?.['required'] ? 'UserName必填' :
          this.userName?.errors?.['minlength'] ? 'UserName长度最少位' :
            this.userName?.errors?.['maxlength'] ? 'UserName长度最多30位' : '';
      case 'roleIds':
        return this.userName?.errors?.['required'] ? '必须选择角色' : '';
      case 'realName':
        return this.realName?.errors?.['required'] ? 'RealName必填' :
          this.realName?.errors?.['minlength'] ? 'RealName长度最少位' :
            this.realName?.errors?.['maxlength'] ? 'RealName长度最多30位' : '';
      case 'position':
        return this.position?.errors?.['required'] ? 'Position必填' :
          this.position?.errors?.['minlength'] ? 'Position长度最少位' :
            this.position?.errors?.['maxlength'] ? 'Position长度最多30位' : '';
      case 'email':
        return this.email?.errors?.['required'] ? 'Email必填' :
          this.email?.errors?.['minlength'] ? 'Email长度最少位' :
            this.email?.errors?.['maxlength'] ? 'Email长度最多100位' : '';
      case 'password':
        return this.password?.errors?.['required'] ? 'Password必填' :
          this.password?.errors?.['minlength'] ? 'Password长度最少位' :
            this.password?.errors?.['maxlength'] ? 'Password长度最多100位' : '';
      case 'phoneNumber':
        return this.phoneNumber?.errors?.['required'] ? 'PhoneNumber必填' :
          this.phoneNumber?.errors?.['minlength'] ? 'PhoneNumber长度最少位' :
            this.phoneNumber?.errors?.['maxlength'] ? 'PhoneNumber长度最多20位' : '';
      case 'avatar':
        return this.avatar?.errors?.['required'] ? 'Avatar必填' :
          this.avatar?.errors?.['minlength'] ? 'Avatar长度最少位' :
            this.avatar?.errors?.['maxlength'] ? 'Avatar长度最多200位' : '';

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
          this.snb.open('添加成功');
          // this.dialogRef.close(res);
          this.router.navigate(['../index'], { relativeTo: this.route });
        });
    }
  }
  back(): void {
    this.location.back();
  }
}
