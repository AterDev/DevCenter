import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { EnvironmentFilterDto } from '../models/environment/environment-filter-dto.model';
import { EnvironmentAddDto } from '../models/environment/environment-add-dto.model';
import { EnvironmentUpdateDto } from '../models/environment/environment-update-dto.model';
import { PageListOfEnvironmentItemDto } from '../models/environment/page-list-of-environment-item-dto.model';
import { Environment } from '../models/environment/environment.model';

/**
 * 环境
 */
@Injectable({ providedIn: 'root' })
export class EnvironmentService extends BaseService {
  /**
   * 筛选
   * @param data EnvironmentFilterDto
   */
  filter(data: EnvironmentFilterDto): Observable<PageListOfEnvironmentItemDto> {
    const url = `/api/Environment/filter`;
    return this.request<PageListOfEnvironmentItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data EnvironmentAddDto
   */
  add(data: EnvironmentAddDto): Observable<Environment> {
    const url = `/api/Environment`;
    return this.request<Environment>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data EnvironmentUpdateDto
   */
  update(id: string, data: EnvironmentUpdateDto): Observable<Environment> {
    const url = `/api/Environment/${id}`;
    return this.request<Environment>('put', url, data);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Environment> {
    const url = `/api/Environment/${id}`;
    return this.request<Environment>('get', url);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<Environment> {
    const url = `/api/Environment/${id}`;
    return this.request<Environment>('delete', url);
  }

}
