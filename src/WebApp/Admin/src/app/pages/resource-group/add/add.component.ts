import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';
import { ResourceGroupAddDto } from 'src/app/share/models/resource-group/resource-group-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';
import { EnvironmentService } from 'src/app/share/services/environment.service';
import { EnvironmentItemDto } from 'src/app/share/models/environment/environment-item-dto.model';
import { NavigationType } from 'src/app/share/models/enum/navigation-type.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  Status = Status;
  NavigationType = NavigationType;
  formGroup!: FormGroup;
  data = {} as ResourceGroupAddDto;
  environments: EnvironmentItemDto[] = [];
  isLoading = true;
  constructor(

    private service: ResourceGroupService,
    private envSrv: EnvironmentService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
  ) {

  }

  get name() { return this.formGroup.get('name'); }
  get descriptioin() { return this.formGroup.get('descriptioin'); }
  get navigationType() { return this.formGroup.get('navigation'); }
  get environmentId() { return this.formGroup.get('environmentId'); }

  ngOnInit(): void {
    this.initForm();
    this.getEnvionments();
  }
  getEnvionments(): void {
    this.envSrv.filter({ pageIndex: 1, pageSize: 100 })
      .subscribe(res => {
        if (res.data) {
          this.environments = res.data
          this.isLoading = false;
        }
      });
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(100)]),
      descriptioin: new FormControl(null, [Validators.maxLength(400)]),
      navigation: new FormControl(NavigationType.WebSite, [Validators.required]),
      environmentId: new FormControl(null, [Validators.required]),
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
      case 'environmentId':
        return this.environmentId?.errors?.['required'] ? 'environmentId必填' : '';

      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as ResourceGroupAddDto;
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
}
