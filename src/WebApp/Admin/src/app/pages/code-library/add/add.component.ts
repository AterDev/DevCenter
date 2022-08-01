import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CodeLibraryService } from 'src/app/share/services/code-library.service';
import { CodeLibrary } from 'src/app/share/models/code-library/code-library.model';
import { CodeLibraryAddDto } from 'src/app/share/models/code-library/code-library-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';

@Component({
    selector: 'app-add',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
    
    formGroup!: FormGroup;
    data = {} as CodeLibraryAddDto;
    isLoading = true;
    constructor(
        
        private service: CodeLibraryService,
        public snb: MatSnackBar,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location
        // public dialogRef: MatDialogRef<AddComponent>,
        // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
    ) {

    }

    get namespace() { return this.formGroup.get('namespace'); }
    get description() { return this.formGroup.get('description'); }
    get language() { return this.formGroup.get('language'); }
    get isValid() { return this.formGroup.get('isValid'); }
    get isPublic() { return this.formGroup.get('isPublic'); }


  ngOnInit(): void {
    this.initForm();
    
    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }
  
  initForm(): void {
    this.formGroup = new FormGroup({
      namespace: new FormControl(null, [Validators.maxLength(100)]),
      description: new FormControl(null, [Validators.maxLength(500)]),
      language: new FormControl(null, [Validators.maxLength(100)]),
      isValid: new FormControl(null, []),
      isPublic: new FormControl(null, []),

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
      case 'language':
        return this.language?.errors?.['required'] ? 'Language必填' :
          this.language?.errors?.['minlength'] ? 'Language长度最少位' :
            this.language?.errors?.['maxlength'] ? 'Language长度最多100位' : '';
      case 'isValid':
        return this.isValid?.errors?.['required'] ? 'IsValid必填' :
          this.isValid?.errors?.['minlength'] ? 'IsValid长度最少位' :
            this.isValid?.errors?.['maxlength'] ? 'IsValid长度最多位' : '';
      case 'isPublic':
        return this.isPublic?.errors?.['required'] ? 'IsPublic必填' :
          this.isPublic?.errors?.['minlength'] ? 'IsPublic长度最少位' :
            this.isPublic?.errors?.['maxlength'] ? 'IsPublic长度最多位' : '';

      default:
    return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
    const data = this.formGroup.value as CodeLibraryAddDto;
    this.data = { ...data, ...this.data };
    this.service.add(this.data)
        .subscribe(res => {
            this.snb.open('添加成功');
            // this.dialogRef.close(res);
            this.router.navigate(['../index'],{relativeTo: this.route});
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
