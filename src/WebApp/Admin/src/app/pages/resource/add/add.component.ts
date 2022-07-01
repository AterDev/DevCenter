import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResourceService } from 'src/app/share/services/resource.service';
import { ResourceAddDto } from 'src/app/share/models/resource/resource-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { lastValueFrom } from 'rxjs';
import { Selection } from 'src/app/share/models/selection.model';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';
import { MatSelectChange } from '@angular/material/select';
import { ResourceAttributeDefineService } from 'src/app/share/services/resource-attribute-define.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  Status = Status;

  formGroup!: FormGroup;
  data = {} as ResourceAddDto;
  isLoading = true;
  groupSelections = [] as Selection[];
  tagSelections = [] as Selection[];
  attributeDefines = [] as ResourceAttributeDefineItemDto[];
  typeDefineSelections = [] as Selection[];
  constructor(
    private service: ResourceService,
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
  get resourceTypeId() { return this.formGroup.get('resourceTypeId'); }
  get groupId() { return this.formGroup.get('groupId'); }
  get tagIds() { return this.formGroup.get('tagIds'); }


  ngOnInit(): void {
    this.getSelectionData();
  }

  async getSelectionData() {
    var res = await lastValueFrom(this.service.getSelectionData());
    if (res) {
      this.groupSelections = res.group!;
      this.tagSelections = res.tags!;
      this.typeDefineSelections = res.typeDefines!;
      this.initForm();
      this.isLoading = false;
    }

  }
  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(100)]),
      description: new FormControl(null, [Validators.maxLength(400)]),
      groupId: new FormControl(null, [Validators.required]),
      resourceTypeId: new FormControl(null, [Validators.required]),
      tagIds: new FormControl(null, []),
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
      case 'resourceTypeId':
        return this.resourceTypeId?.errors?.['required'] ? '必须选择一种类型' : '';
      case 'groupId':
        return this.resourceTypeId?.errors?.['required'] ? '必须选择资源组' : '';
      default:
        return '';
    }
  }

  typeSwitch(event: MatSelectChange) {

    this.attributeDefineSrv.filter({
      pageIndex: 1, pageSize: 20, typeId: event.value
    }).subscribe(res => {
      if (res) {
        this.attributeDefines = res.data!;
      }
    });
  }
  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as ResourceAddDto;
      this.data = { ...data, ...this.data };
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
