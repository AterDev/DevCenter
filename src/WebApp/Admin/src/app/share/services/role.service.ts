import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { RoleFilterDto } from '../models/role/role-filter-dto.model';
import { RoleAddDto } from '../models/role/role-add-dto.model';
import { RoleUpdateDto } from '../models/role/role-update-dto.model';
import { RoleResourceDto } from '../models/role/role-resource-dto.model';
import { PageListOfRoleItemDto } from '../models/role/page-list-of-role-item-dto.model';
import { Role } from '../models/role/role.model';

/**
 * 角色表
 */
@Injectable({ providedIn: 'root' })
export class RoleService extends BaseService {
  /**
   * 筛选
   * @param data RoleFilterDto
   */
  filter(data: RoleFilterDto): Observable<PageListOfRoleItemDto> {
    const url = `/api/Role/filter`;
    return this.request<PageListOfRoleItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data RoleAddDto
   */
  add(data: RoleAddDto): Observable<Role> {
    const url = `/api/Role`;
    return this.request<Role>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data RoleUpdateDto
   */
  update(id: string, data: RoleUpdateDto): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('put', url, data);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('get', url);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('delete', url);
  }

  /**
   * 分配资源组
   * @param data RoleResourceDto
   */
  setResourceGroups(data: RoleResourceDto): Observable<boolean> {
    const url = `/api/Role/resourceGroup`;
    return this.request<boolean>('put', url, data);
  }

}
