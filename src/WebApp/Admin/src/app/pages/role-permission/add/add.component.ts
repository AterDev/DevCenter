import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RolePermissionService } from 'src/app/share/services/role-permission.service';
import { RolePermission } from 'src/app/share/models/role-permission/role-permission.model';
import { RolePermissionUpdateDto } from 'src/app/share/models/role-permission/role-permission-update-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { PermissionTypeMyProperty } from 'src/app/share/models/enum/permission-type-my-property.model';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
    selector: 'app-add',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
    PermissionTypeMyProperty = PermissionTypeMyProperty;
Status = Status;

    formGroup!: FormGroup;
    data = {} as RolePermissionUpdateDto;
    isLoading = true;
    constructor(
        
        private service: RolePermissionService,
        public snb: MatSnackBar,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location
        // public dialogRef: MatDialogRef<AddComponent>,
        // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
    ) {

    }

    get permissionTypeMyProperty() { return this.formGroup.get('permissionTypeMyProperty'); }
    get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.initForm();
    
    // TODO:获取其他相关数据后设置加载状态
    // this.isLoading = false;
  }
  
  initForm(): void {
    this.formGroup = new FormGroup({
      permissionTypeMyProperty: new FormControl(null, []),
      status: new FormControl(null, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'permissionTypeMyProperty':
        return this.permissionTypeMyProperty?.errors?.['required'] ? 'PermissionTypeMyProperty必填' :
          this.permissionTypeMyProperty?.errors?.['minlength'] ? 'PermissionTypeMyProperty长度最少位' :
            this.permissionTypeMyProperty?.errors?.['maxlength'] ? 'PermissionTypeMyProperty长度最多位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';

      default:
    return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
    const data = this.formGroup.value as RolePermissionUpdateDto;
    this.data = { ...data, ...this.data };
    this.service.add(this.data as RolePermission)
        .subscribe(res => {
            this.snb.open('添加成功');
            // this.dialogRef.close(res);
            // this.router.navigate(['../index'],{relativeTo: this.route});
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
            this.data.logoUrl = res.url;
          }, error => {
            this.snb.open(error?.detail);
          }); */
    } else {

    }
  }
}
