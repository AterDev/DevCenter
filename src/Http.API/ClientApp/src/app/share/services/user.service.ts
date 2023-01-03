import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { UserFilterDto } from '../models/user/user-filter-dto.model';
import { UserAddDto } from '../models/user/user-add-dto.model';
import { UserUpdateDto } from '../models/user/user-update-dto.model';
import { PageListOfUserItemDto } from '../models/user/page-list-of-user-item-dto.model';
import { User } from '../models/user/user.model';
import { UserShortDto } from '../models/user/user-short-dto.model';

/**
 * 系统用户
 */
@Injectable({ providedIn: 'root' })
export class UserService extends BaseService {
  /**
   * 筛选
   * @param data UserFilterDto
   */
  filter(data: UserFilterDto): Observable<PageListOfUserItemDto> {
    const url = `/api/User/filter`;
    return this.request<PageListOfUserItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data UserAddDto
   */
  add(data: UserAddDto): Observable<User> {
    const url = `/api/User`;
    return this.request<User>('post', url, data);
  }

  /**
   * 获取当前用户信息
   */
  getMyInfo(): Observable<UserShortDto> {
    const url = `/api/User`;
    return this.request<UserShortDto>('get', url);
  }

  /**
   * 更新
   * @param id string
   * @param data UserUpdateDto
   */
  update(id: string, data: UserUpdateDto): Observable<User> {
    const url = `/api/User/${id}`;
    return this.request<User>('put', url, data);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<User> {
    const url = `/api/User/${id}`;
    return this.request<User>('get', url);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<User> {
    const url = `/api/User/${id}`;
    return this.request<User>('delete', url);
  }

  /**
   * 修改密码
   * @param newPassword string
   */
  changePassword(newPassword?: string): Observable<boolean> {
    const url = `/api/User/changePassword?newPassword=${newPassword}`;
    return this.request<boolean>('put', url);
  }

}
