import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RolePermission } from 'src/app/share/models/role-permission/role-permission.model';
import { RolePermissionService } from 'src/app/share/services/role-permission.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RolePermissionUpdateDto } from 'src/app/share/models/role-permission/role-permission-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { PermissionTypeMyProperty } from 'src/app/share/models/enum/permission-type-my-property.model';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  PermissionTypeMyProperty = PermissionTypeMyProperty;
Status = Status;

  id!: string;
  isLoading = true;
  data = {} as RolePermission;
  updateData = {} as RolePermissionUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private service: RolePermissionService,
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

    get permissionTypeMyProperty() { return this.formGroup.get('permissionTypeMyProperty'); }
    get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.getDetail();
    
    // TODO:获取其他相关数据后设置加载状态
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
      permissionTypeMyProperty: new FormControl(this.data.permissionTypeMyProperty, []),
      status: new FormControl(this.data.status, []),

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
  edit(): void {
    if(this.formGroup.valid) {
      this.updateData = this.formGroup.value as RolePermissionUpdateDto;
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
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
            this.updateData.logoUrl = res.url;
          }, error => {
            this.snb.open(error?.detail);
          }); */
    } else {

    }
  }

}
