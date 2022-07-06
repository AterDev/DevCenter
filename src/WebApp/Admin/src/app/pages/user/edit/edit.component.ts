import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/share/models/user/user.model';
import { UserService } from 'src/app/share/services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserUpdateDto } from 'src/app/share/models/user/user-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  Status = Status;

  id!: string;
  isLoading = true;
  data = {} as User;
  updateData = {} as UserUpdateDto;
  formGroup!: FormGroup;
    constructor(

    private service: UserService,
    private snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<EditComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空
    }
  }

    get userName() { return this.formGroup.get('userName'); }
    get realName() { return this.formGroup.get('realName'); }
    get position() { return this.formGroup.get('position'); }
    get email() { return this.formGroup.get('email'); }
    get emailConfirmed() { return this.formGroup.get('emailConfirmed'); }
    get phoneNumber() { return this.formGroup.get('phoneNumber'); }
    get phoneNumberConfirmed() { return this.formGroup.get('phoneNumberConfirmed'); }
    get avatar() { return this.formGroup.get('avatar'); }
    get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.getDetail();

    // TODO:等待数据加载完成
    // this.isLoading = false;
  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.data = res;
        this.initForm();
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      userName: new FormControl(this.data.userName, [Validators.maxLength(30)]),
      realName: new FormControl(this.data.realName, [Validators.maxLength(30)]),
      position: new FormControl(this.data.position, [Validators.maxLength(30)]),
      email: new FormControl(this.data.email, [Validators.maxLength(100)]),
      emailConfirmed: new FormControl(this.data.emailConfirmed, []),
      phoneNumber: new FormControl(this.data.phoneNumber, [Validators.maxLength(20)]),
      phoneNumberConfirmed: new FormControl(this.data.phoneNumberConfirmed, []),
      avatar: new FormControl(this.data.avatar, [Validators.maxLength(200)]),
      status: new FormControl(this.data.status, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'userName':
        return this.userName?.errors?.['required'] ? 'UserName必填' :
          this.userName?.errors?.['minlength'] ? 'UserName长度最少位' :
            this.userName?.errors?.['maxlength'] ? 'UserName长度最多30位' : '';
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
      case 'emailConfirmed':
        return this.emailConfirmed?.errors?.['required'] ? 'EmailConfirmed必填' :
          this.emailConfirmed?.errors?.['minlength'] ? 'EmailConfirmed长度最少位' :
            this.emailConfirmed?.errors?.['maxlength'] ? 'EmailConfirmed长度最多位' : '';
      case 'phoneNumber':
        return this.phoneNumber?.errors?.['required'] ? 'PhoneNumber必填' :
          this.phoneNumber?.errors?.['minlength'] ? 'PhoneNumber长度最少位' :
            this.phoneNumber?.errors?.['maxlength'] ? 'PhoneNumber长度最多20位' : '';
      case 'phoneNumberConfirmed':
        return this.phoneNumberConfirmed?.errors?.['required'] ? 'PhoneNumberConfirmed必填' :
          this.phoneNumberConfirmed?.errors?.['minlength'] ? 'PhoneNumberConfirmed长度最少位' :
            this.phoneNumberConfirmed?.errors?.['maxlength'] ? 'PhoneNumberConfirmed长度最多位' : '';
      case 'avatar':
        return this.avatar?.errors?.['required'] ? 'Avatar必填' :
          this.avatar?.errors?.['minlength'] ? 'Avatar长度最少位' :
            this.avatar?.errors?.['maxlength'] ? 'Avatar长度最多200位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';

      default:
        return '';
    }
  }
  edit(): void {
    if(this.formGroup.valid) {
      this.updateData = this.formGroup.value as UserUpdateDto;
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
           // this.dialogRef.close(res);
          this.router.navigate(['../../index'],{relativeTo: this.route});
        });
    }
  }

  back(): void {
    this.location.back();
  }

  upload(event: any, type ?: string): void {
    const files = event.target.files;
    if(files[0]) {
    const formdata = new FormData();
    formdata.append('file', files[0]);
    /*    this.service.uploadFile('agent-info' + type, formdata)
          .subscribe(res => {
            this.updateData.logoUrl = res.url;
          }, error => {
            this.snb.open(error?.detail);
          }); */
    } else {

    }
  }

}
