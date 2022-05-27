import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { PermissionFilterDto } from '../models/permission/permission-filter-dto.model';
import { PermissionAddDto } from '../models/permission/permission-add-dto.model';
import { PermissionUpdateDto } from '../models/permission/permission-update-dto.model';
import { PageResultOfPermissionItemDto } from '../models/permission/page-result-of-permission-item-dto.model';
import { Permission } from '../models/permission/permission.model';

/**
 * 权限
 */
@Injectable({ providedIn: 'root' })
export class PermissionService extends BaseService {
  /**
   * 分页筛选
   * @param data PermissionFilterDto
   */
  filter(data: PermissionFilterDto): Observable<PageResultOfPermissionItemDto> {
    const url = `/api/Permission/filter`;
    return this.request<PageResultOfPermissionItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data PermissionAddDto
   */
  add(data: PermissionAddDto): Observable<Permission> {
    const url = `/api/Permission`;
    return this.request<Permission>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data PermissionUpdateDto
   */
  update(id: string, data: PermissionUpdateDto): Observable<Permission> {
    const url = `/api/Permission/${id}`;
    return this.request<Permission>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/Permission/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Permission> {
    const url = `/api/Permission/${id}`;
    return this.request<Permission>('get', url);
  }

}
