import { trigger, state, style, transition, animate } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { NavigationType } from 'src/app/share/models/enum/navigation-type.model';
import { EnvironmentItemDto } from 'src/app/share/models/environment/environment-item-dto.model';
import { ResourceAttribute } from 'src/app/share/models/resource-attribute/resource-attribute.model';
import { ResourceGroupFilterDto } from 'src/app/share/models/resource-group/resource-group-filter-dto.model';
import { ResourceGroupItemDto } from 'src/app/share/models/resource-group/resource-group-item-dto.model';
import { Resource } from 'src/app/share/models/resource/resource.model';
import { EnvironmentService } from 'src/app/share/services/environment.service';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ServerComponent implements OnInit {
  isLoading = true;
  filter = {} as ResourceGroupFilterDto;
  environments: EnvironmentItemDto[] = [];
  environmentId: string | null = null;
  groups: ResourceGroupItemDto[] = [];
  dataSource!: MatTableDataSource<Resource>;
  columnsToDisplay = ['name', 'ipAddress', 'port', 'description'];
  expandedElement: ResourceGroupItemDto | null = null;
  columnsToDisplayWithExpand = [...this.columnsToDisplay, 'expand'];
  constructor(
    private envSrv: EnvironmentService,
    private groupSrv: ResourceGroupService,
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
      console.log(resources);

      this.dataSource = new MatTableDataSource<Resource>(resources);
    }
  }
  getAttributeValue(resource: Resource, name: string) {
    const item = resource.attributes?.find(val => val.name == name);
    console.log(resource, name);

    return item?.value;
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  sortAttributes(attributes: ResourceAttribute[]) {
    return attributes.sort((a, b) => a.sort - b.sort);
  }
}
