import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResourceAttribute } from 'src/app/share/models/resource-attribute/resource-attribute.model';
import { ResourceAttributeService } from 'src/app/share/services/resource-attribute.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ResourceAttributeUpdateDto } from 'src/app/share/models/resource-attribute/resource-attribute-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { environment } from 'src/environments/environment';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  public editorConfig!: CKEditor5.Config;
  public editor: CKEditor5.EditorConstructor = ClassicEditor;
  Status = Status;

  id!: string;
  isLoading = true;
  data = {} as ResourceAttribute;
  updateData = {} as ResourceAttributeUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private authService: OidcSecurityService,
    private service: ResourceAttributeService,
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

    get displayName() { return this.formGroup.get('displayName'); }
    get name() { return this.formGroup.get('name'); }
    get isEnable() { return this.formGroup.get('isEnable'); }
    get value() { return this.formGroup.get('value'); }
    get sort() { return this.formGroup.get('sort'); }
    get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.getDetail();
    this.initEditor();
    // TODO:获取其他相关数据后设置加载状态
    // this.isLoading = false;
  }
    initEditor(): void {
    this.editorConfig = {
      // placeholder: '请添加图文信息提供证据，也可以直接从Word文档中复制',
      simpleUpload: {
        uploadUrl: environment.uploadEditorFileUrl,
        headers: {
          Authorization: 'Bearer ' + this.authService.getAccessToken()
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
      displayName: new FormControl(this.data.displayName, [Validators.maxLength(50)]),
      name: new FormControl(this.data.name, [Validators.maxLength(60)]),
      isEnable: new FormControl(this.data.isEnable, []),
      value: new FormControl(this.data.value, [Validators.maxLength(2000)]),
      sort: new FormControl(this.data.sort, []),
      status: new FormControl(this.data.status, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'displayName':
        return this.displayName?.errors?.['required'] ? 'DisplayName必填' :
          this.displayName?.errors?.['minlength'] ? 'DisplayName长度最少位' :
            this.displayName?.errors?.['maxlength'] ? 'DisplayName长度最多50位' : '';
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多60位' : '';
      case 'isEnable':
        return this.isEnable?.errors?.['required'] ? 'IsEnable必填' :
          this.isEnable?.errors?.['minlength'] ? 'IsEnable长度最少位' :
            this.isEnable?.errors?.['maxlength'] ? 'IsEnable长度最多位' : '';
      case 'value':
        return this.value?.errors?.['required'] ? 'Value必填' :
          this.value?.errors?.['minlength'] ? 'Value长度最少位' :
            this.value?.errors?.['maxlength'] ? 'Value长度最多2000位' : '';
      case 'sort':
        return this.sort?.errors?.['required'] ? 'Sort必填' :
          this.sort?.errors?.['minlength'] ? 'Sort长度最少位' :
            this.sort?.errors?.['maxlength'] ? 'Sort长度最多位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';

      default:
        return '';
    }
  }
  edit(): void {
    if(this.formGroup.valid) {
      this.updateData = this.formGroup.value as ResourceAttributeUpdateDto;
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
