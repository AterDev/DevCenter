import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { UserFilterDto } from '../models/user/user-filter-dto.model';
import { UserAddDto } from '../models/user/user-add-dto.model';
import { UserUpdateDto } from '../models/user/user-update-dto.model';
import { PageResultOfUserItemDto } from '../models/user/page-result-of-user-item-dto.model';
import { UserShortDto } from '../models/user/user-short-dto.model';
import { User } from '../models/user/user.model';

/**
 * 系统用户
 */
@Injectable({ providedIn: 'root' })
export class UserService extends BaseService {
  /**
   * changePassword
   * @param newPassword string
   */
  changePassword(newPassword?: string): Observable<boolean> {
    const url = `/api/User/changePassword?newPassword=${newPassword}`;
    return this.request<boolean>('put', url);
  }

  /**
   * 分页筛选
   * @param data UserFilterDto
   */
  filter(data: UserFilterDto): Observable<PageResultOfUserItemDto> {
    const url = `/api/User/filter`;
    return this.request<PageResultOfUserItemDto>('post', url, data);
  }

  /**
   * 获取当前用户信息
   */
  getMyInfo(): Observable<UserShortDto> {
    const url = `/api/User`;
    return this.request<UserShortDto>('get', url);
  }

  /**
   * 添加
   * @param data UserAddDto
   */
  add(data: UserAddDto): Observable<User> {
    const url = `/api/User`;
    return this.request<User>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data UserUpdateDto
   */
  update(id: string, data: UserUpdateDto): Observable<User> {
    const url = `/api/User/${id}`;
    return this.request<User>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/User/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<User> {
    const url = `/api/User/${id}`;
    return this.request<User>('get', url);
  }

}
