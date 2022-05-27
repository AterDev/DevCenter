import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { RolePermissionFilterDto } from '../models/role-permission/role-permission-filter-dto.model';
import { RolePermissionAddDto } from '../models/role-permission/role-permission-add-dto.model';
import { RolePermissionUpdateDto } from '../models/role-permission/role-permission-update-dto.model';
import { PageResultOfRolePermissionItemDto } from '../models/role-permission/page-result-of-role-permission-item-dto.model';
import { RolePermission } from '../models/role-permission/role-permission.model';

/**
 * 角色权限中间表
 */
@Injectable({ providedIn: 'root' })
export class RolePermissionService extends BaseService {
  /**
   * 分页筛选
   * @param data RolePermissionFilterDto
   */
  filter(data: RolePermissionFilterDto): Observable<PageResultOfRolePermissionItemDto> {
    const url = `/api/RolePermission/filter`;
    return this.request<PageResultOfRolePermissionItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data RolePermissionAddDto
   */
  add(data: RolePermissionAddDto): Observable<RolePermission> {
    const url = `/api/RolePermission`;
    return this.request<RolePermission>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data RolePermissionUpdateDto
   */
  update(id: string, data: RolePermissionUpdateDto): Observable<RolePermission> {
    const url = `/api/RolePermission/${id}`;
    return this.request<RolePermission>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/RolePermission/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<RolePermission> {
    const url = `/api/RolePermission/${id}`;
    return this.request<RolePermission>('get', url);
  }

}
