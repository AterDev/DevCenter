import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BlogService } from 'src/app/share/services/blog.service';
import { Blog } from 'src/app/share/models/blog/blog.model';
import { BlogAddDto } from 'src/app/share/models/blog/blog-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { environment } from 'src/environments/environment';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
// import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
    selector: 'app-add',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
    public editorConfig!: CKEditor5.Config;
  public editor: CKEditor5.EditorConstructor = ClassicEditor;
  
    formGroup!: FormGroup;
    data = {} as BlogAddDto;
    isLoading = true;
    constructor(
        
    // private authService: OidcSecurityService,
        private service: BlogService,
        public snb: MatSnackBar,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location
        // public dialogRef: MatDialogRef<AddComponent>,
        // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
    ) {

    }

    get title() { return this.formGroup.get('title'); }
    get summary() { return this.formGroup.get('summary'); }
    get authorName() { return this.formGroup.get('authorName'); }
    get isPrivate() { return this.formGroup.get('isPrivate'); }
    get content() { return this.formGroup.get('content'); }


  ngOnInit(): void {
    this.initForm();
    this.initEditor();
    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }
    initEditor(): void {
    this.editorConfig = {
      // placeholder: '请添加图文信息提供证据，也可以直接从Word文档中复制',
      simpleUpload: {
        uploadUrl: environment.uploadEditorFileUrl,
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem("accessToken")
        }
      },
      language: 'zh-cn'
    };
  }
  onReady(editor: any) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }
  initForm(): void {
    this.formGroup = new FormGroup({
      title: new FormControl(null, [Validators.maxLength(100)]),
      summary: new FormControl(null, [Validators.maxLength(500)]),
      authorName: new FormControl(null, [Validators.maxLength(100)]),
      isPrivate: new FormControl(null, []),
      content: new FormControl(null, [Validators.maxLength(12000)]),

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
            this.content?.errors?.['maxlength'] ? 'Content长度最多12000位' : '';

      default:
    return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
    const data = this.formGroup.value as BlogAddDto;
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
}
