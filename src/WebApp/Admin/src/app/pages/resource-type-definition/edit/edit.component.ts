import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResourceTypeDefinition } from 'src/app/share/models/resource-type-definition/resource-type-definition.model';
import { ResourceTypeDefinitionService } from 'src/app/share/services/resource-type-definition.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ResourceTypeDefinitionUpdateDto } from 'src/app/share/models/resource-type-definition/resource-type-definition-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';
import { ResourceAttributeDefineService } from 'src/app/share/services/resource-attribute-define.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  Status = Status;
  id!: string;
  isLoading = true;
  data = {} as ResourceTypeDefinition;
  updateData = {} as ResourceTypeDefinitionUpdateDto;

  attributeDefines: ResourceAttributeDefineItemDto[] = [];
  formGroup!: FormGroup;
  constructor(

    private service: ResourceTypeDefinitionService,
    private attributeDefineSrv: ResourceAttributeDefineService,
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
  get icon() { return this.formGroup.get('icon'); }
  get color() { return this.formGroup.get('color'); }
  get attributeDefineIds() { return this.formGroup.get('attributeDefineIds'); }
  get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.getDetail();
  }

  getDetail(): void {
    this.attributeDefineSrv.filter({ pageIndex: 1, pageSize: 30 })
      .subscribe(res => {
        if (res) {
          this.attributeDefines = res.data!;
          this.service.getDetail(this.id)
            .subscribe(res => {
              this.data = res;
              this.initForm();
              this.isLoading = false;
            });
        }
      })
  }

  initForm(): void {
    var attributeDefineIds = this.data.attributeDefines?.map(d => d.id);
    this.formGroup = new FormGroup({
      name: new FormControl(this.data.name, [Validators.maxLength(100)]),
      description: new FormControl(this.data.description, [Validators.maxLength(400)]),
      icon: new FormControl(this.data.icon, [Validators.maxLength(300)]),
      color: new FormControl(this.data.color, [Validators.maxLength(12)]),
      attributeDefineIds: new FormControl(attributeDefineIds, [Validators.required]),
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
            this.description?.errors?.['maxlength'] ? 'Description长度最多400位' : '';
      case 'icon':
        return this.icon?.errors?.['required'] ? 'Icon必填' :
          this.icon?.errors?.['minlength'] ? 'Icon长度最少位' :
            this.icon?.errors?.['maxlength'] ? 'Icon长度最多300位' : '';
      case 'color':
        return this.color?.errors?.['required'] ? 'Color必填' :
          this.color?.errors?.['minlength'] ? 'Color长度最少位' :
            this.color?.errors?.['maxlength'] ? 'Color长度最多12位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';
      case 'attributeDefineIds':
        return this.color?.errors?.['required'] ? '请选择包含的属性' : '';
      default:
        return '';
    }
  }
  edit(): void {
    if (this.formGroup.valid) {
      this.updateData = this.formGroup.value as ResourceTypeDefinitionUpdateDto;
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
}
