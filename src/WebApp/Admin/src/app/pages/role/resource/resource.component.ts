import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';
import { ResourceGroupRoleDto } from 'src/app/share/models/resource-group/resource-group-role-dto.model';
import { lastValueFrom } from 'rxjs';
import { MatSelectionListChange } from '@angular/material/list';
@Component({
  selector: 'app-resource',
  templateUrl: './resource.component.html',
  styleUrls: ['./resource.component.css']
})
export class ResourceComponent implements OnInit {
  id!: string;
  isLoading = true;
  groups = [] as ResourceGroupRoleDto[];
  roleGroups = [] as ResourceGroupRoleDto[];
  selectedGroupIds: string[] | null = null;
  constructor(
    private route: ActivatedRoute,
    private groupSrv: ResourceGroupService,
    private location: Location
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空
    }
  }

  ngOnInit(): void {
    this.getResourceGroups();
  }

  async getResourceGroups() {
    let res = await lastValueFrom(this.groupSrv.getRoleResourceGroups(this.id));
    if (res) {
      this.roleGroups = res;
      this.selectedGroupIds = res.map(r => r.id);
    }
    res = await lastValueFrom(this.groupSrv.getRoleResourceGroups(''))
    if (res)
      this.groups = res;

    this.isLoading = false;
  }

  /**
   * 资源组是否在角色中
   * @param id
   */
  inRole(id: string): boolean {
    return this.roleGroups.find((item) => item.id == id) != undefined;
  }
  selectChange(event: MatSelectionListChange): void {
    this.selectedGroupIds = event.source._value;
  }
  back(): void {
    this.location.back();
  }
}
