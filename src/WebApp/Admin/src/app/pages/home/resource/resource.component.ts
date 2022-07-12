import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { NavigationType } from 'src/app/share/models/enum/navigation-type.model';
import { EnvironmentItemDto } from 'src/app/share/models/environment/environment-item-dto.model';
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
      navigation: NavigationType.Server,
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
}
