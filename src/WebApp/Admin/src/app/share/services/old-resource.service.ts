import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ResourceFilterDto } from '../models/old-resource/resource-filter-dto.model';
import { ResourceAddDto } from '../models/old-resource/resource-add-dto.model';
import { ResourceUpdateDto } from '../models/old-resource/resource-update-dto.model';
import { PageListOfResourceItemDto } from '../models/old-resource/page-list-of-resource-item-dto.model';
import { ResourceSelectDataDto } from '../models/old-resource/resource-select-data-dto.model';
import { Resource } from '../models/old-resource/resource.model';

/**
 * 资源
 */
@Injectable({ providedIn: 'root' })
export class OldResourceService extends BaseService {
  /**
   * 分页筛选
   * @param data ResourceFilterDto
   */
  filter(data: ResourceFilterDto): Observable<PageListOfResourceItemDto> {
    const url = `/api/OldResource/filter`;
    return this.request<PageListOfResourceItemDto>('post', url, data);
  }

  /**
   * 获取关联的选项
   */
  getSelectionData(): Observable<ResourceSelectDataDto> {
    const url = `/api/OldResource/selection`;
    return this.request<ResourceSelectDataDto>('get', url);
  }

  /**
   * getAllResources
   */
  getAllResources(): Observable<Resource[]> {
    const url = `/api/OldResource`;
    return this.request<Resource[]>('get', url);
  }

  /**
   * 添加
   * @param data ResourceAddDto
   */
  add(data: ResourceAddDto): Observable<Resource> {
    const url = `/api/OldResource`;
    return this.request<Resource>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ResourceUpdateDto
   */
  update(id: string, data: ResourceUpdateDto): Observable<Resource> {
    const url = `/api/OldResource/${id}`;
    return this.request<Resource>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/OldResource/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Resource> {
    const url = `/api/OldResource/${id}`;
    return this.request<Resource>('get', url);
  }

}
