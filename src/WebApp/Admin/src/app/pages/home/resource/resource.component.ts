import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { NavigationType } from 'src/app/share/models/enum/navigation-type.model';
import { EnvironmentItemDto } from 'src/app/share/models/environment/environment-item-dto.model';
import { ResourceAttribute } from 'src/app/share/models/resource-attribute/resource-attribute.model';
import { ResourceGroupFilterDto } from 'src/app/share/models/resource-group/resource-group-filter-dto.model';
import { ResourceGroupItemDto } from 'src/app/share/models/resource-group/resource-group-item-dto.model';
import { Resource } from 'src/app/share/models/resource/resource.model';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';

@Component({
  selector: 'app-resource',
  templateUrl: './resource.component.html',
  styleUrls: ['./resource.component.css']
})
export class ResourceComponent implements OnInit {
  isLoading = true;
  filter = {} as ResourceGroupFilterDto;
  groups: ResourceGroupItemDto[] = [];
  environments: EnvironmentItemDto[] = [];
  constructor(
    private groupSrv: ResourceGroupService
  ) {
    this.filter = {
      pageIndex: 1,
      pageSize: 30,
      navigation: NavigationType.Tools,
      environmentId: null
    };
  }

  ngOnInit(): void {
    this.getResourceGroup();
  }
  async getResourceGroup() {
    let res = await lastValueFrom(this.groupSrv.filter(this.filter));
    if (res) {
      this.groups = res.data!;
      const resources = res.data?.flatMap(g => g.resource!);
    }
    this.isLoading = false;
  }
  getResourceUrl(attributes: ResourceAttribute[]): string | null {
    var attr = attributes.find(a => a.name == 'url');
    var faviconUrl = attributes.find(a => a.name == 'favicon');
    if (faviconUrl) {
      return faviconUrl.value;
    } else if (attr?.value) {
      const url = new URL(attr.value);
      return url.origin + "/favicon.ico";
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
    var attr = resource.attributes!.find(a => a.name == 'url');
    if (attr?.value) {
      window.open(attr?.value);
    }
  }

  openTool(url: string) {
    window.open('/tool/' + url);
  }
}
