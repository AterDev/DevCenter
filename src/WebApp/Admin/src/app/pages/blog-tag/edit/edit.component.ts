import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogTag } from 'src/app/share/models/blog-tag/blog-tag.model';
import { BlogTagService } from 'src/app/share/services/blog-tag.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BlogTagUpdateDto } from 'src/app/share/models/blog-tag/blog-tag-update-dto.model';
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
  data = {} as BlogTag;
  updateData = {} as BlogTagUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private service: BlogTagService,
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
    get color() { return this.formGroup.get('color'); }
    get icon() { return this.formGroup.get('icon'); }
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
      name: new FormControl(this.data.name, [Validators.maxLength(100)]),
      color: new FormControl(this.data.color, [Validators.maxLength(20)]),
      icon: new FormControl(this.data.icon, [Validators.maxLength(30)]),
      status: new FormControl(this.data.status, []),
      isDeleted: new FormControl(this.data.isDeleted, []),

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
    if(this.formGroup.valid) {
      this.updateData = this.formGroup.value as BlogTagUpdateDto;
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
