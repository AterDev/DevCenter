import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResourceGroup } from 'src/app/share/models/resource-group/resource-group.model';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ResourceGroupUpdateDto } from 'src/app/share/models/resource-group/resource-group-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { EnvironmentItemDto } from 'src/app/share/models/environment/environment-item-dto.model';
import { EnvironmentService } from 'src/app/share/services/environment.service';
import { NavigationType } from 'src/app/share/models/enum/navigation-type.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  Status = Status;
  NavigationType = NavigationType;
  id!: string;
  isLoading = true;
  data = {} as ResourceGroup;
  environments: EnvironmentItemDto[] = [];
  updateData = {} as ResourceGroupUpdateDto;
  formGroup!: FormGroup;
  constructor(

    private service: ResourceGroupService,
    private snb: MatSnackBar,
    private router: Router,
    private envSrv: EnvironmentService,
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
  get descriptioin() { return this.formGroup.get('descriptioin'); }
  get navigationType() { return this.formGroup.get('navigation'); }
  get status() { return this.formGroup.get('status'); }
  get environmentId() { return this.formGroup.get('environmentId'); }

  ngOnInit(): void {
    this.getDetail();
    this.getEnvionments();

    // TODO:获取其他相关数据后设置加载状态

  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.data = res;
        this.initForm();
      })
  }
  getEnvionments(): void {
    this.envSrv.filter({ pageIndex: 1, pageSize: 100 })
      .subscribe(res => {
        if (res.data) {
          this.environments = res.data
          this.initForm();
          this.isLoading = false;
        }
      });
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(this.data.name, [Validators.maxLength(100)]),
      descriptioin: new FormControl(this.data.descriptioin, [Validators.maxLength(400)]),
      navigation: new FormControl(this.data.navigation, [Validators.required]),
      environmentId: new FormControl(this.data.environment?.id, [Validators.required]),
      sort: new FormControl(this.data.sort, [Validators.min(0)]),
      status: new FormControl(this.data.status, []),
    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多100位' : '';
      case 'descriptioin':
        return this.descriptioin?.errors?.['required'] ? 'Descriptioin必填' :
          this.descriptioin?.errors?.['minlength'] ? 'Descriptioin长度最少位' :
            this.descriptioin?.errors?.['maxlength'] ? 'Descriptioin长度最多400位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';
      case 'environmentId':
        return this.environmentId?.errors?.['required'] ? 'environmentId必填' : '';
      default:
        return '';
    }
  }
  edit(): void {
    if (this.formGroup.valid) {
      this.updateData = this.formGroup.value as ResourceGroupUpdateDto;
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
