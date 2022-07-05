import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { LoginService } from 'src/app/auth/login.service';
import { FilterBase } from 'src/app/share/models/filter-base.model';
import { EnvironmentService } from 'src/app/share/services/environment.service';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';
import { EnvironmentItemDto } from 'src/app/share/models/environment/environment-item-dto.model';
import { ResourceGroupItemDto } from 'src/app/share/models/resource-group/resource-group-item-dto.model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ResourceDialogComponent } from '../resource-dialog/resource-dialog.component';
import { ResourceGroupFilterDto } from 'src/app/share/models/resource-group/resource-group-filter-dto.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  isLogin = false;
  isLoading = true;
  filter = {} as ResourceGroupFilterDto;
  environments: EnvironmentItemDto[] = [];
  environmentId: string | null = null;
  selectedResourceIds: string[] = [];
  groups: ResourceGroupItemDto[] = [];
  constructor(
    private loginService: LoginService,
    private envSrv: EnvironmentService,
    private groupSrv: ResourceGroupService,
    public dialogRef: MatDialogRef<ResourceDialogComponent>,
    public dialog: MatDialog

  ) {
    this.isLogin = loginService.isLogin;
    this.filter = { pageIndex: 1, pageSize: 30, environmentId: null };
  }

  ngOnInit(): void {
    Promise.all([this.getEnvironments(), this.getResourceGroup()])
      .then(data => {
        this.isLoading = false;
      });
  }

  async getEnvironments() {
    let res = await lastValueFrom(this.envSrv.filter(this.filter));
    if (res) {
      this.environments = res.data!;
    }
  }

  async getResourceGroup() {
    let res = await lastValueFrom(this.groupSrv.filter(this.filter));
    if (res) {
      this.groups = res.data!;
    }
  }

  showResource(): void {
    let selectedId = this.selectedResourceIds[0];
    let resource = this.groups.flatMap(g => g.resource).find(val => val!.id == selectedId);
    this.dialog.open(ResourceDialogComponent, {
      data: resource
    });
  }
}
