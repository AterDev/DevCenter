import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResourceTypeDefinitionService } from 'src/app/share/services/resource-type-definition.service';
import { ResourceTypeDefinition } from 'src/app/share/models/resource-type-definition/resource-type-definition.model';
import { ResourceTypeDefinitionAddDto } from 'src/app/share/models/resource-type-definition/resource-type-definition-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { ResourceAttributeDefineService } from 'src/app/share/services/resource-attribute-define.service';
import { ResourceAttributeDefineAddDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-add-dto.model';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';
import { MatSelectionListChange } from '@angular/material/list';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  Status = Status;
  formGroup!: FormGroup;
  data = {} as ResourceTypeDefinitionAddDto;
  attributeDefines: ResourceAttributeDefineItemDto[] = [];
  isLoading = true;
  constructor(

    private service: ResourceTypeDefinitionService,
    private attributeDefineSrv: ResourceAttributeDefineService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

  get name() { return this.formGroup.get('name'); }
  get description() { return this.formGroup.get('description'); }
  get icon() { return this.formGroup.get('icon'); }
  get color() { return this.formGroup.get('color'); }
  get attributeDefineIds() { return this.formGroup.get('attributeDefineIds'); }

  ngOnInit(): void {
    this.initForm();
    this.getAttributeDefines();
  }
  getAttributeDefines(): void {
    this.attributeDefineSrv.filter({ pageIndex: 1, pageSize: 30 })
      .subscribe(res => {
        if (res) {
          this.attributeDefines = res.data!;
          this.isLoading = false;
        }
      })
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(100)]),
      description: new FormControl(null, [Validators.maxLength(400)]),
      icon: new FormControl(null, [Validators.maxLength(300)]),
      color: new FormControl(null, [Validators.maxLength(12)]),
      attributeDefineIds: new FormControl([], [Validators.required]),
    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name??????' :
          this.name?.errors?.['minlength'] ? 'Name???????????????' :
            this.name?.errors?.['maxlength'] ? 'Name????????????100???' : '';
      case 'description':
        return this.description?.errors?.['required'] ? 'Description??????' :
          this.description?.errors?.['minlength'] ? 'Description???????????????' :
            this.description?.errors?.['maxlength'] ? 'Description????????????400???' : '';
      case 'icon':
        return this.icon?.errors?.['required'] ? 'Icon??????' :
          this.icon?.errors?.['minlength'] ? 'Icon???????????????' :
            this.icon?.errors?.['maxlength'] ? 'Icon????????????300???' : '';
      case 'color':
        return this.color?.errors?.['required'] ? 'Color??????' :
          this.color?.errors?.['minlength'] ? 'Color???????????????' :
            this.color?.errors?.['maxlength'] ? 'Color????????????12???' : '';
      case 'attributeDefineIds':
        return this.color?.errors?.['required'] ? '????????????????????????' : '';
      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as ResourceTypeDefinitionAddDto;
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
  upload(event: any, type?: string): void {
    const files = event.target.files;
    if (files[0]) {
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
