import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RoleService } from 'src/app/share/services/role.service';
import { Role } from 'src/app/share/models/role/role.model';
import { RoleAddDto } from 'src/app/share/models/role/role-add-dto.model';
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
  formGroup!: FormGroup;
  data = {} as RoleAddDto;
  isLoading = true;
  constructor(

    private service: RoleService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

  get name() { return this.formGroup.get('name'); }
  get identifyName() { return this.formGroup.get('identifyName'); }
  get description() { return this.formGroup.get('description'); }

  ngOnInit(): void {
    this.initForm();

    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(30)]),
      identifyName: new FormControl(null, [Validators.maxLength(30)]),
      description: new FormControl(null, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多30位' : '';
      case 'identifyName':
        return this.identifyName?.errors?.['required'] ? 'IdentifyName必填' :
          this.identifyName?.errors?.['minlength'] ? 'IdentifyName长度最少位' :
            this.identifyName?.errors?.['maxlength'] ? 'IdentifyName长度最多30位' : '';
      case 'description':
        return this.description?.errors?.['required'] ? 'Description必填' :
          this.description?.errors?.['minlength'] ? 'Description长度最少位' :
            this.description?.errors?.['maxlength'] ? 'Description长度最多位' : '';

      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as RoleAddDto;
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
