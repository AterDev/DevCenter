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

    this.isLoading = false;
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      displayName: new FormControl(null, [Validators.maxLength(50)]),
      name: new FormControl(null, [Validators.maxLength(60)]),
      isEnable: new FormControl(true, []),
      required: new FormControl(false, []),
      sort: new FormControl(0, []),
      status: new FormControl(Status.Default, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'displayName':
        return this.displayName?.errors?.['required'] ? 'DisplayName??????' :
          this.displayName?.errors?.['minlength'] ? 'DisplayName???????????????' :
            this.displayName?.errors?.['maxlength'] ? 'DisplayName????????????50???' : '';
      case 'name':
        return this.name?.errors?.['required'] ? 'Name??????' :
          this.name?.errors?.['minlength'] ? 'Name???????????????' :
            this.name?.errors?.['maxlength'] ? 'Name????????????60???' : '';
      case 'isEnable':
        return this.isEnable?.errors?.['required'] ? 'IsEnable??????' :
          this.isEnable?.errors?.['minlength'] ? 'IsEnable???????????????' :
            this.isEnable?.errors?.['maxlength'] ? 'IsEnable???????????????' : '';
      case 'required':
        return this.required?.errors?.['required'] ? 'Required??????' :
          this.required?.errors?.['minlength'] ? 'Required???????????????' :
            this.required?.errors?.['maxlength'] ? 'Required???????????????' : '';
      case 'sort':
        return this.sort?.errors?.['required'] ? 'Sort??????' :
          this.sort?.errors?.['minlength'] ? 'Sort???????????????' :
            this.sort?.errors?.['maxlength'] ? 'Sort???????????????' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status??????' :
          this.status?.errors?.['minlength'] ? 'Status???????????????' :
            this.status?.errors?.['maxlength'] ? 'Status???????????????' : '';

      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as ResourceAttributeDefineAddDto;
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
