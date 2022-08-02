import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Blog } from 'src/app/share/models/blog/blog.model';
import { BlogService } from 'src/app/share/services/blog.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BlogUpdateDto } from 'src/app/share/models/blog/blog-update-dto.model';
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
  data = {} as Blog;
  updateData = {} as BlogUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private service: BlogService,
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

    get title() { return this.formGroup.get('title'); }
    get summary() { return this.formGroup.get('summary'); }
    get authorName() { return this.formGroup.get('authorName'); }
    get isPrivate() { return this.formGroup.get('isPrivate'); }
    get content() { return this.formGroup.get('content'); }
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
      title: new FormControl(this.data.title, [Validators.maxLength(100)]),
      summary: new FormControl(this.data.summary, [Validators.maxLength(500)]),
      authorName: new FormControl(this.data.authorName, [Validators.maxLength(100)]),
      isPrivate: new FormControl(this.data.isPrivate, []),
      content: new FormControl(this.data.content, []),
      status: new FormControl(this.data.status, []),
      isDeleted: new FormControl(this.data.isDeleted, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'title':
        return this.title?.errors?.['required'] ? 'Title必填' :
          this.title?.errors?.['minlength'] ? 'Title长度最少位' :
            this.title?.errors?.['maxlength'] ? 'Title长度最多100位' : '';
      case 'summary':
        return this.summary?.errors?.['required'] ? 'Summary必填' :
          this.summary?.errors?.['minlength'] ? 'Summary长度最少位' :
            this.summary?.errors?.['maxlength'] ? 'Summary长度最多500位' : '';
      case 'authorName':
        return this.authorName?.errors?.['required'] ? 'AuthorName必填' :
          this.authorName?.errors?.['minlength'] ? 'AuthorName长度最少位' :
            this.authorName?.errors?.['maxlength'] ? 'AuthorName长度最多100位' : '';
      case 'isPrivate':
        return this.isPrivate?.errors?.['required'] ? 'IsPrivate必填' :
          this.isPrivate?.errors?.['minlength'] ? 'IsPrivate长度最少位' :
            this.isPrivate?.errors?.['maxlength'] ? 'IsPrivate长度最多位' : '';
      case 'content':
        return this.content?.errors?.['required'] ? 'Content必填' :
          this.content?.errors?.['minlength'] ? 'Content长度最少位' :
            this.content?.errors?.['maxlength'] ? 'Content长度最多位' : '';
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
      this.updateData = this.formGroup.value as BlogUpdateDto;
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
