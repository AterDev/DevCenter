import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CodeSnippetService } from 'src/app/share/services/code-snippet.service';
import { CodeSnippet } from 'src/app/share/models/code-snippet/code-snippet.model';
import { CodeSnippetAddDto } from 'src/app/share/models/code-snippet/code-snippet-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { environment } from 'src/environments/environment';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
// import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Language } from 'src/app/share/models/enum/language.model';
import { CodeType } from 'src/app/share/models/enum/code-type.model';
import { MonacoEditorConstructionOptions, MonacoStandaloneCodeEditor } from '@materia-ui/ngx-monaco-editor';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  // public editorConfig!: CKEditor5.Config;
  // public editor: CKEditor5.EditorConstructor = ClassicEditor;
  public editor!: MonacoStandaloneCodeEditor;
  public editorOption: MonacoEditorConstructionOptions;
  Language = Language;
  CodeType = CodeType;
  formGroup!: FormGroup;
  data = {} as CodeSnippetAddDto;
  isLoading = true;
  constructor(

    // private authService: OidcSecurityService,
    private service: CodeSnippetService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

    this.editorOption = {
      theme: 'vs-dark',
      language: 'csharp',
      minimap: { enabled: false }
    }
  }

  get name() { return this.formGroup.get('name'); }
  get description() { return this.formGroup.get('description'); }
  get content() { return this.formGroup.get('content'); }
  get language() { return this.formGroup.get('language'); }
  get codeType() { return this.formGroup.get('codeType'); }


  ngOnInit(): void {
    this.initForm();
    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }
  editorInit(editor: MonacoStandaloneCodeEditor) {
    // Here you can access editor instance
    this.editor = editor;
  }
  changeLanguage(event: any): void {
    const language = Language[event.value].toLowerCase();
    console.log(language);
    const model = this.editor.getModel();
    monaco.editor.setModelLanguage(model!, language);
    this.editorOption.language = language;
  }
  onReady(editor: any) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }
  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(100)]),
      description: new FormControl(null, [Validators.maxLength(500)]),
      content: new FormControl(null, [Validators.maxLength(5000)]),
      language: new FormControl(Language.Csharp, []),
      codeType: new FormControl(CodeType.Entity, []),

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

      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as CodeSnippetAddDto;
      this.data = data;
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
