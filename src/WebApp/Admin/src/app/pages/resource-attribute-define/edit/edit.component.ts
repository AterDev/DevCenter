import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResourceAttributeDefine } from 'src/app/share/models/resource-attribute-define/resource-attribute-define.model';
import { ResourceAttributeDefineService } from 'src/app/share/services/resource-attribute-define.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ResourceAttributeDefineUpdateDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-update-dto.model';
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
  data = {} as ResourceAttributeDefine;
  updateData = {} as ResourceAttributeDefineUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private service: ResourceAttributeDefineService,
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

    get displayName() { return this.formGroup.get('displayName'); }
    get name() { return this.formGroup.get('name'); }
    get isEnable() { return this.formGroup.get('isEnable'); }
    get required() { return this.formGroup.get('required'); }
    get sort() { return this.formGroup.get('sort'); }
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
      displayName: new FormControl(this.data.displayName, [Validators.maxLength(50)]),
      name: new FormControl(this.data.name, [Validators.maxLength(60)]),
      isEnable: new FormControl(this.data.isEnable, []),
      required: new FormControl(this.data.required, []),
      sort: new FormControl(this.data.sort, []),
      status: new FormControl(this.data.status, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'displayName':
        return this.displayName?.errors?.['required'] ? 'DisplayName必填' :
          this.displayName?.errors?.['minlength'] ? 'DisplayName长度最少位' :
            this.displayName?.errors?.['maxlength'] ? 'DisplayName长度最多50位' : '';
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多60位' : '';
      case 'isEnable':
        return this.isEnable?.errors?.['required'] ? 'IsEnable必填' :
          this.isEnable?.errors?.['minlength'] ? 'IsEnable长度最少位' :
            this.isEnable?.errors?.['maxlength'] ? 'IsEnable长度最多位' : '';
      case 'required':
        return this.required?.errors?.['required'] ? 'Required必填' :
          this.required?.errors?.['minlength'] ? 'Required长度最少位' :
            this.required?.errors?.['maxlength'] ? 'Required长度最多位' : '';
      case 'sort':
        return this.sort?.errors?.['required'] ? 'Sort必填' :
          this.sort?.errors?.['minlength'] ? 'Sort长度最少位' :
            this.sort?.errors?.['maxlength'] ? 'Sort长度最多位' : '';
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
      this.updateData = this.formGroup.value as ResourceAttributeDefineUpdateDto;
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
