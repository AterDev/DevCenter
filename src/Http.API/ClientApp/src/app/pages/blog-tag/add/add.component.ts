import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BlogTagService } from 'src/app/share/services/blog-tag.service';
import { BlogTag } from 'src/app/share/models/blog-tag/blog-tag.model';
import { BlogTagAddDto } from 'src/app/share/models/blog-tag/blog-tag-add-dto.model';
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
    data = {} as BlogTagAddDto;
    isLoading = true;
    constructor(
        
        private service: BlogTagService,
        public snb: MatSnackBar,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location
        // public dialogRef: MatDialogRef<AddComponent>,
        // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
    ) {

    }

    get name() { return this.formGroup.get('name'); }
    get color() { return this.formGroup.get('color'); }
    get icon() { return this.formGroup.get('icon'); }


  ngOnInit(): void {
    this.initForm();
    
    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }
  
  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(100)]),
      color: new FormControl(null, [Validators.maxLength(20)]),
      icon: new FormControl(null, [Validators.maxLength(30)]),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多100位' : '';
      case 'color':
        return this.color?.errors?.['required'] ? 'Color必填' :
          this.color?.errors?.['minlength'] ? 'Color长度最少位' :
            this.color?.errors?.['maxlength'] ? 'Color长度最多20位' : '';
      case 'icon':
        return this.icon?.errors?.['required'] ? 'Icon必填' :
          this.icon?.errors?.['minlength'] ? 'Icon长度最少位' :
            this.icon?.errors?.['maxlength'] ? 'Icon长度最多30位' : '';

      default:
    return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
    const data = this.formGroup.value as BlogTagAddDto;
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
