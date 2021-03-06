import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray, AbstractControl } from '@angular/forms';
import { ResourceService } from 'src/app/share/services/resource.service';
import { ResourceAddDto } from 'src/app/share/models/resource/resource-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { lastValueFrom } from 'rxjs';
import { Selection } from 'src/app/share/models/resource/selection.model';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';
import { MatSelectChange } from '@angular/material/select';
import { ResourceAttributeDefineService } from 'src/app/share/services/resource-attribute-define.service';
import { AttributeControlService } from '../dynamic-form-attribute/attribute-control.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
  providers: [AttributeControlService]
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
  defaultGroupId: string | null;
  constructor(
    private service: ResourceService,
    private attributeDefineSrv: ResourceAttributeDefineService,
    public attributeControlSrv: AttributeControlService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {
    this.defaultGroupId = this.route.snapshot.paramMap.get('groupId');
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
      groupId: new FormControl(this.defaultGroupId, [Validators.required]),
      resourceTypeId: new FormControl(null, [Validators.required]),
      tagIds: new FormControl(null, []),
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
      case 'resourceTypeId':
        return this.resourceTypeId?.errors?.['required'] ? '????????????????????????' : '';
      case 'groupId':
        return this.resourceTypeId?.errors?.['required'] ? '?????????????????????' : '';
      default:
        return '';
    }
  }

  typeSwitch(event: MatSelectChange) {
    this.attributeDefineSrv.filter({
      pageIndex: 1, pageSize: 20, typeId: event.value
    }).subscribe(res => {
      if (res) {
        // this.attributeControlSrv.buildAttributeForm(res.data!);
        this.attributeDefines = res.data!;
        this.attributeDefines.sort((a, b) => a.sort - b.sort);
        this.attributeControlSrv.buildAttributeForm(this.attributeDefines);
      }
    });
  }
  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as ResourceAddDto;
      this.data = { ...data, ...this.data };
      this.data.attributeAddItem = this.attributeControlSrv.getAttributes();

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
