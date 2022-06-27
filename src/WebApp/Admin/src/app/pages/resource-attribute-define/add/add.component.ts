import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResourceAttributeDefineService } from 'src/app/share/services/resource-attribute-define.service';
import { ResourceAttributeDefine } from 'src/app/share/models/resource-attribute-define/resource-attribute-define.model';
import { ResourceAttributeDefineAddDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
    selector: 'app-add',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
    Status = Status;

    formGroup!: FormGroup;
    data = {} as ResourceAttributeDefineAddDto;
    isLoading = true;
    constructor(
        
        private service: ResourceAttributeDefineService,
        public snb: MatSnackBar,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location
        // public dialogRef: MatDialogRef<AddComponent>,
        // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
    ) {

    }

    get displayName() { return this.formGroup.get('displayName'); }
    get name() { return this.formGroup.get('name'); }
    get isEnable() { return this.formGroup.get('isEnable'); }
    get required() { return this.formGroup.get('required'); }
    get sort() { return this.formGroup.get('sort'); }
    get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.initForm();
    
    // TODO:获取其他相关数据后设置加载状态
    // this.isLoading = false;
  }
  
  initForm(): void {
    this.formGroup = new FormGroup({
      displayName: new FormControl(null, [Validators.maxLength(50)]),
      name: new FormControl(null, [Validators.maxLength(60)]),
      isEnable: new FormControl(null, []),
      required: new FormControl(null, []),
      sort: new FormControl(null, []),
      status: new FormControl(null, []),

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

  add(): void {
    if(this.formGroup.valid) {
    const data = this.formGroup.value as ResourceAttributeDefineAddDto;
    this.data = { ...data, ...this.data };
    this.service.add(this.data)
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
