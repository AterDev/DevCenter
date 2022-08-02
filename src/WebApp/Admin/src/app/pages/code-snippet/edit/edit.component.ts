import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CodeSnippet } from 'src/app/share/models/code-snippet/code-snippet.model';
import { CodeSnippetService } from 'src/app/share/services/code-snippet.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CodeSnippetUpdateDto } from 'src/app/share/models/code-snippet/code-snippet-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { environment } from 'src/environments/environment';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
// import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Language } from 'src/app/share/models/enum/language.model';
import { CodeType } from 'src/app/share/models/enum/code-type.model';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  public editorConfig!: CKEditor5.Config;
  public editor: CKEditor5.EditorConstructor = ClassicEditor;
  Language = Language;
  CodeType = CodeType;
  Status = Status;

  id!: string;
  isLoading = true;
  data = {} as CodeSnippet;
  updateData = {} as CodeSnippetUpdateDto;
  formGroup!: FormGroup;
  constructor(

    // private authService: OidcSecurityService,
    private service: CodeSnippetService,
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
  get description() { return this.formGroup.get('description'); }
  get content() { return this.formGroup.get('content'); }
  get language() { return this.formGroup.get('language'); }
  get codeType() { return this.formGroup.get('codeType'); }
  get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.getDetail();
    this.initEditor();
    // TODO:等待数据加载完成
    // this.isLoading = false;
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
      description: new FormControl(this.data.description, [Validators.maxLength(500)]),
      content: new FormControl(this.data.content, [Validators.maxLength(5000)]),
      language: new FormControl(this.data.language, []),
      codeType: new FormControl(this.data.codeType, []),
      status: new FormControl(this.data.status, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多100位' : '';
      case 'description':
        return this.description?.errors?.['required'] ? 'Description必填' :
          this.description?.errors?.['minlength'] ? 'Description长度最少位' :
            this.description?.errors?.['maxlength'] ? 'Description长度最多500位' : '';
      case 'content':
        return this.content?.errors?.['required'] ? 'Content必填' :
          this.content?.errors?.['minlength'] ? 'Content长度最少位' :
            this.content?.errors?.['maxlength'] ? 'Content长度最多5000位' : '';
      case 'language':
        return this.language?.errors?.['required'] ? 'Language必填' :
          this.language?.errors?.['minlength'] ? 'Language长度最少位' :
            this.language?.errors?.['maxlength'] ? 'Language长度最多位' : '';
      case 'codeType':
        return this.codeType?.errors?.['required'] ? 'CodeType必填' :
          this.codeType?.errors?.['minlength'] ? 'CodeType长度最少位' :
            this.codeType?.errors?.['maxlength'] ? 'CodeType长度最多位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';

      default:
        return '';
    }
  }
  edit(): void {
    if (this.formGroup.valid) {
      this.updateData = this.formGroup.value as CodeSnippetUpdateDto;
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
          // this.dialogRef.close(res);
          this.router.navigate(['../../index'], { relativeTo: this.route });
        });
    }
  }

  back(): void {
    this.location.back();
  }

}
