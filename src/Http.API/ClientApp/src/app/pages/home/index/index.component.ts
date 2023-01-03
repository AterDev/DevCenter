import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { LoginService } from 'src/app/auth/login.service';
import { EnvironmentService } from 'src/app/share/services/environment.service';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';
import { EnvironmentItemDto } from 'src/app/share/models/environment/environment-item-dto.model';
import { ResourceGroupItemDto } from 'src/app/share/models/resource-group/resource-group-item-dto.model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ResourceDialogComponent } from '../resource-dialog/resource-dialog.component';
import { ResourceGroupFilterDto } from 'src/app/share/models/resource-group/resource-group-filter-dto.model';
import { NavigationType } from 'src/app/share/models/enum/navigation-type.model';
import { ResourceAttribute } from 'src/app/share/models/resource-attribute/resource-attribute.model';
import { Resource } from 'src/app/share/models/resource/resource.model';
import { ResourceService } from '../resource.service';

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
    private resourceSrv: ResourceService,
    public dialog: MatDialog

  ) {
    this.isLogin = this.loginService.isLogin;
    this.filter = {
      pageIndex: 1,
      pageSize: 30,
      navigation: NavigationType.WebSite,
      environmentId: null
    };
  }

  ngOnInit(): void {
    Promise.all([this.getResourceGroup(), this.getEnvironments()])
      .then(data => {
        this.isLoading = false;
      });
  }

  async getEnvironments() {
    let res = await lastValueFrom(this.envSrv.filter(this.filter));
    if (res) {
      this.environments = res.data?.reverse()!;
    }
  }

  async getResourceGroup() {
    let res = await lastValueFrom(this.groupSrv.filter(this.filter));
    if (res) {
      this.groups = res.data!;
    }
  }
  getResourceUrl(attributes: ResourceAttribute[]): string | null {
    var attr = attributes.find(a => a.name == 'url');
    var faviconUrl = attributes.find(a => a.name == 'favicon');
    if (faviconUrl && faviconUrl.value !== '') {
      return faviconUrl.value;
    }
    return null;
  }

  showName(name: string): string {
    if (name.length > 10) {
      return name.slice(0, 10) + '...';
    }
    return name;
  }

  openWebsite(resource: Resource) {
    var more = resource.attributes!
      .find(a => a.name == 'username'
        || a.name == 'password'
        || a.name == 'host');
    if (more?.value) {
      this.dialog.open(ResourceDialogComponent, {
        data: resource
      });
    } else {
      var attr = resource.attributes!.find(a => a.name == 'url');
      if (attr?.value) {
        window.open(attr?.value);
      }
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
