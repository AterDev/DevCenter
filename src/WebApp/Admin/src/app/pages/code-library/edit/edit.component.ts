import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CodeLibrary } from 'src/app/share/models/code-library/code-library.model';
import { CodeLibraryService } from 'src/app/share/services/code-library.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CodeLibraryUpdateDto } from 'src/app/share/models/code-library/code-library-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { LibraryType } from 'src/app/share/models/enum/library-type.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  Status = Status;
  LibraryType = LibraryType
  id!: string;
  isLoading = true;
  data = {} as CodeLibrary;
  updateData = {} as CodeLibraryUpdateDto;
  formGroup!: FormGroup;
  constructor(
    private service: CodeLibraryService,
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

  get namespace() { return this.formGroup.get('namespace'); }
  get description() { return this.formGroup.get('description'); }
  get type() { return this.formGroup.get('type'); }
  get isValid() { return this.formGroup.get('isValid'); }
  get isPublic() { return this.formGroup.get('isPublic'); }
  get status() { return this.formGroup.get('status'); }
  get isDeleted() { return this.formGroup.get('isDeleted'); }


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
      namespace: new FormControl(this.data.namespace, [Validators.maxLength(100)]),
      description: new FormControl(this.data.description, [Validators.maxLength(500)]),
      type: new FormControl(this.data.type, [Validators.maxLength(100)]),
      isValid: new FormControl(this.data.isValid, []),
      isPublic: new FormControl(this.data.isPublic, []),
      status: new FormControl(this.data.status, []),
      isDeleted: new FormControl(this.data.isDeleted, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'namespace':
        return this.namespace?.errors?.['required'] ? 'Namespace必填' :
          this.namespace?.errors?.['minlength'] ? 'Namespace长度最少位' :
            this.namespace?.errors?.['maxlength'] ? 'Namespace长度最多100位' : '';
      case 'description':
        return this.description?.errors?.['required'] ? 'Description必填' :
          this.description?.errors?.['minlength'] ? 'Description长度最少位' :
            this.description?.errors?.['maxlength'] ? 'Description长度最多500位' : '';
      case 'type':
        return this.type?.errors?.['required'] ? 'type必填' :
          this.type?.errors?.['minlength'] ? 'type长度最少位' :
            this.type?.errors?.['maxlength'] ? 'type长度最多100位' : '';
      case 'isValid':
        return this.isValid?.errors?.['required'] ? 'IsValid必填' :
          this.isValid?.errors?.['minlength'] ? 'IsValid长度最少位' :
            this.isValid?.errors?.['maxlength'] ? 'IsValid长度最多位' : '';
      case 'isPublic':
        return this.isPublic?.errors?.['required'] ? 'IsPublic必填' :
          this.isPublic?.errors?.['minlength'] ? 'IsPublic长度最少位' :
            this.isPublic?.errors?.['maxlength'] ? 'IsPublic长度最多位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';
      case 'isDeleted':
        return this.isDeleted?.errors?.['required'] ? 'IsDeleted必填' :
          this.isDeleted?.errors?.['minlength'] ? 'IsDeleted长度最少位' :
            this.isDeleted?.errors?.['maxlength'] ? 'IsDeleted长度最多位' : '';

      default:
        return '';
    }
  }
  edit(): void {
    if (this.formGroup.valid) {
      this.updateData = this.formGroup.value as CodeLibraryUpdateDto;
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
          // this.dialogRef.close(res);
          this.router.navigate(['../index'],{relativeTo: this.route});
        });
    }
  }

  back(): void {
    this.location.back();
  }

  upload(event: any, type?: string): void {
    const files = event.target.files;
    if (files[0]) {
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
