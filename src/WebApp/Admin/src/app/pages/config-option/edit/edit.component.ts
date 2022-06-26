import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfigOption } from 'src/app/share/models/config-option/config-option.model';
import { ConfigOptionService } from 'src/app/share/services/config-option.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfigOptionUpdateDto } from 'src/app/share/models/config-option/config-option-update-dto.model';
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
  data = {} as ConfigOption;
  updateData = {} as ConfigOptionUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private service: ConfigOptionService,
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

    get name() { return this.formGroup.get('name'); }
    get displayValue() { return this.formGroup.get('displayValue'); }
    get value() { return this.formGroup.get('value'); }
    get minValue() { return this.formGroup.get('minValue'); }
    get maxValue() { return this.formGroup.get('maxValue'); }
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
      name: new FormControl(this.data.name, [Validators.maxLength(60)]),
      displayValue: new FormControl(this.data.displayValue, [Validators.maxLength(20)]),
      value: new FormControl(this.data.value, [Validators.maxLength(100)]),
      minValue: new FormControl(this.data.minValue, [Validators.maxLength(40)]),
      maxValue: new FormControl(this.data.maxValue, [Validators.maxLength(40)]),
      status: new FormControl(this.data.status, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多60位' : '';
      case 'displayValue':
        return this.displayValue?.errors?.['required'] ? 'DisplayValue必填' :
          this.displayValue?.errors?.['minlength'] ? 'DisplayValue长度最少位' :
            this.displayValue?.errors?.['maxlength'] ? 'DisplayValue长度最多20位' : '';
      case 'value':
        return this.value?.errors?.['required'] ? 'Value必填' :
          this.value?.errors?.['minlength'] ? 'Value长度最少位' :
            this.value?.errors?.['maxlength'] ? 'Value长度最多100位' : '';
      case 'minValue':
        return this.minValue?.errors?.['required'] ? 'MinValue必填' :
          this.minValue?.errors?.['minlength'] ? 'MinValue长度最少位' :
            this.minValue?.errors?.['maxlength'] ? 'MinValue长度最多40位' : '';
      case 'maxValue':
        return this.maxValue?.errors?.['required'] ? 'MaxValue必填' :
          this.maxValue?.errors?.['minlength'] ? 'MaxValue长度最少位' :
            this.maxValue?.errors?.['maxlength'] ? 'MaxValue长度最多40位' : '';
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
      this.updateData = this.formGroup.value as ConfigOptionUpdateDto;
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
