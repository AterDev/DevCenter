import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ResourceGroupFilterDto } from '../models/resource-group/resource-group-filter-dto.model';
import { ResourceGroupAddDto } from '../models/resource-group/resource-group-add-dto.model';
import { ResourceGroupUpdateDto } from '../models/resource-group/resource-group-update-dto.model';
import { PageListOfResourceGroupItemDto } from '../models/resource-group/page-list-of-resource-group-item-dto.model';
import { ResourceGroupItemDto } from '../models/resource-group/resource-group-item-dto.model';
import { ResourceGroupRoleDto } from '../models/resource-group/resource-group-role-dto.model';
import { ResourceGroup } from '../models/resource-group/resource-group.model';

/**
 * 资源组
 */
@Injectable({ providedIn: 'root' })
export class ResourceGroupService extends BaseService {
  /**
   * 筛选
   * @param data ResourceGroupFilterDto
   */
  filter(data: ResourceGroupFilterDto): Observable<PageListOfResourceGroupItemDto> {
    const url = `/api/ResourceGroup/filter`;
    return this.request<PageListOfResourceGroupItemDto>('post', url, data);
  }

  /**
   * 资源组列表
   */
  getList(): Observable<ResourceGroupItemDto[]> {
    const url = `/api/ResourceGroup/list`;
    return this.request<ResourceGroupItemDto[]>('post', url);
  }

  /**
   * 获取某角色分配的资源组
   * @param roleId string
   */
  getRoleResourceGroups(roleId?: string): Observable<ResourceGroupRoleDto[]> {
    const url = `/api/ResourceGroup/role?roleId=${roleId}`;
    return this.request<ResourceGroupRoleDto[]>('get', url);
  }

  /**
   * 新增
   * @param data ResourceGroupAddDto
   */
  add(data: ResourceGroupAddDto): Observable<ResourceGroup> {
    const url = `/api/ResourceGroup`;
    return this.request<ResourceGroup>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data ResourceGroupUpdateDto
   */
  update(id: string, data: ResourceGroupUpdateDto): Observable<ResourceGroup> {
    const url = `/api/ResourceGroup/${id}`;
    return this.request<ResourceGroup>('put', url, data);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ResourceGroup> {
    const url = `/api/ResourceGroup/${id}`;
    return this.request<ResourceGroup>('get', url);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<ResourceGroup> {
    const url = `/api/ResourceGroup/${id}`;
    return this.request<ResourceGroup>('delete', url);
  }

}
