import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';
import { ResourceGroupRoleDto } from 'src/app/share/models/resource-group/resource-group-role-dto.model';
import { lastValueFrom } from 'rxjs';
import { MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import { RoleService } from 'src/app/share/services/role.service';
import { RoleResourceDto } from 'src/app/share/models/role/role-resource-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
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
  selectedGroupIds: string[] = [];
  @ViewChild('grouplist') groupList!: MatSelectionList;
  constructor(
    private route: ActivatedRoute,
    private groupSrv: ResourceGroupService,
    private roleSrv: RoleService,
    private router: Router,
    private snb: MatSnackBar,
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
    this.selectedGroupIds = event.source._value || [];
  }
  selectAll(): void {
    this.groupList.selectAll();
    this.selectedGroupIds = this.groups.map(g => g.id);
  }

  deselectAll(): void {
    this.groupList.deselectAll();
    this.selectedGroupIds = [];
  }

  async save(): Promise<void> {
    let data: RoleResourceDto = {
      roleId: this.id,
      groupIds: this.selectedGroupIds
    };
    let res = await lastValueFrom(this.roleSrv.setResourceGroups(data));
    if (res) {
      this.snb.open('保存成功');
      this.router.navigate(['../../index'], { relativeTo: this.route });
    } else {
      this.snb.open('保存失败');
    }
  }
  back(): void {
    this.location.back();
  }
}
