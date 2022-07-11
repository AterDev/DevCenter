import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Resource } from 'src/app/share/models/resource/resource.model';
import { ResourceService } from 'src/app/share/services/resource.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ResourceUpdateDto } from 'src/app/share/models/resource/resource-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Selection } from 'src/app/share/models/resource/selection.model';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { lastValueFrom } from 'rxjs';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';
import { ResourceAttributeDefineService } from 'src/app/share/services/resource-attribute-define.service';
import { AttributeControlService } from '../dynamic-form-attribute/attribute-control.service';
import { MatSelectChange } from '@angular/material/select';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  providers: [AttributeControlService]
})
export class EditComponent implements OnInit {
  Status = Status;

  id!: string;
  isLoading = true;
  canLoadChildForm = false;
  data = {} as Resource;
  groupSelections = [] as Selection[];
  tagSelections = [] as Selection[];
  attributeDefines = [] as ResourceAttributeDefineItemDto[];
  typeDefineSelections = [] as Selection[];
  updateData = {} as ResourceUpdateDto;
  formGroup!: FormGroup;
  constructor(

    private service: ResourceService,
    private attributeDefineSrv: ResourceAttributeDefineService,
    public attributeControlSrv: AttributeControlService,
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
    }
  }

  get name() { return this.formGroup.get('name'); }
  get description() { return this.formGroup.get('description'); }
  get status() { return this.formGroup.get('status'); }
  get resourceTypeId() { return this.formGroup.get('resourceTypeId'); }
  get groupId() { return this.formGroup.get('groupId'); }
  get tagIds() { return this.formGroup.get('tagIds'); }


  ngOnInit(): void {
    this.getInitData();
  }

  async getInitData() {
    let res = await lastValueFrom(this.service.getSelectionData());
    if (res) {
      this.groupSelections = res.group!;
      this.tagSelections = res.tags!;
      this.typeDefineSelections = res.typeDefines!;
    }
    let detail = await lastValueFrom(this.service.getDetail(this.id));
    if (detail) {
      this.data = detail;
    }
    this.initForm();
  }

  initForm(): void {
    var tagIds = this.data.tags?.map(t => t.id);
    this.formGroup = new FormGroup({
      name: new FormControl(this.data.name, [Validators.maxLength(100)]),
      description: new FormControl(this.data.description, [Validators.maxLength(400)]),
      status: new FormControl(this.data.status, []),
      groupId: new FormControl(this.data.group?.id, [Validators.required]),
      resourceTypeId: new FormControl(this.data.resourceType?.id, [Validators.required]),
      tagIds: new FormControl(tagIds, []),

    });
    this.getAttributeDefines(this.data.resourceType?.id!);
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
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';
      case 'resourceTypeId':
        return this.resourceTypeId?.errors?.['required'] ? '必须选择一种类型' : '';
      case 'groupId':
        return this.resourceTypeId?.errors?.['required'] ? '必须选择资源组' : '';
      default:
        return '';
    }
  }

  getAttributeDefines(typeId: string): void {
    this.attributeDefineSrv.filter({
      pageIndex: 1, pageSize: 20, typeId
    }).subscribe(res => {
      if (res) {
        this.attributeDefines = res.data!;
        // 获取value
        this.attributeDefines.forEach((define) => {
          var attribute = this.data.attributes?.find((val) => val.name === define.name);
          define.value = attribute?.value;
        });
        console.log(this.attributeDefines);

        this.attributeControlSrv.buildAttributeForm(this.attributeDefines);
        this.canLoadChildForm = true;
      }
      this.isLoading = false;
    });
  }
  typeSwitch(event: MatSelectChange) {
    this.getAttributeDefines(event.value);
  }
  edit(): void {
    if (this.formGroup.valid) {
      this.updateData = this.formGroup.value as ResourceUpdateDto;
      this.updateData.attributeAddItem = this.attributeControlSrv.getAttributes();
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
          // this.dialogRef.close(res);
          this.router.navigate(['../../index'], { relativeTo: this.route });
        });
    }
  }

  back(): void {
    this.router.navigate(['../../index'], { relativeTo: this.route });
  }

  upload(event: any, type?: string): void {
    const files = event.target.files;
    if (files[0]) {
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
