import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { RoleFilterDto } from '../models/role/role-filter-dto.model';
import { RoleAddDto } from '../models/role/role-add-dto.model';
import { RoleUpdateDto } from '../models/role/role-update-dto.model';
import { PageResultOfRoleItemDto } from '../models/role/page-result-of-role-item-dto.model';
import { Role } from '../models/role/role.model';

/**
 * 角色表
 */
@Injectable({ providedIn: 'root' })
export class RoleService extends BaseService {
  /**
   * 分页筛选
   * @param data RoleFilterDto
   */
  filter(data: RoleFilterDto): Observable<PageResultOfRoleItemDto> {
    const url = `/api/Role/filter`;
    return this.request<PageResultOfRoleItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data RoleAddDto
   */
  add(data: RoleAddDto): Observable<Role> {
    const url = `/api/Role`;
    return this.request<Role>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data RoleUpdateDto
   */
  update(id: string, data: RoleUpdateDto): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/Role/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('get', url);
  }

}
