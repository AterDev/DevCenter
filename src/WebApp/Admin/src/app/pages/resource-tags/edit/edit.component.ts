import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResourceTags } from 'src/app/share/models/resource-tags/resource-tags.model';
import { ResourceTagsService } from 'src/app/share/services/resource-tags.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ResourceTagsUpdateDto } from 'src/app/share/models/resource-tags/resource-tags-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { CommonColors } from 'src/app/share/const';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  Status = Status;

  id!: string;
  isLoading = true;
  data = {} as ResourceTags;
  updateData = {} as ResourceTagsUpdateDto;
  formGroup!: FormGroup;
  colors = CommonColors;
  constructor(

    private service: ResourceTagsService,
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
  get color() { return this.formGroup.get('color'); }
  get icon() { return this.formGroup.get('icon'); }
  get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.getDetail();

    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
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
      color: new FormControl(this.data.color, []),
      icon: new FormControl(this.data.icon, []),
      status: new FormControl(this.data.status, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多100位' : '';
      case 'color':
        return this.color?.errors?.['required'] ? 'Color必填' :
          this.color?.errors?.['minlength'] ? 'Color长度最少位' :
            this.color?.errors?.['maxlength'] ? 'Color长度最多位' : '';
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
      this.updateData = this.formGroup.value as ResourceTagsUpdateDto;
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
