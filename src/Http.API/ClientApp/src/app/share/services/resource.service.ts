import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ResourceFilterDto } from '../models/resource/resource-filter-dto.model';
import { ResourceAddDto } from '../models/resource/resource-add-dto.model';
import { ResourceUpdateDto } from '../models/resource/resource-update-dto.model';
import { PageListOfResourceItemDto } from '../models/resource/page-list-of-resource-item-dto.model';
import { ResourceSelectDataDto } from '../models/resource/resource-select-data-dto.model';
import { Resource } from '../models/resource/resource.model';

/**
 * 资源
 */
@Injectable({ providedIn: 'root' })
export class ResourceService extends BaseService {
  /**
   * 筛选
   * @param data ResourceFilterDto
   */
  filter(data: ResourceFilterDto): Observable<PageListOfResourceItemDto> {
    const url = `/api/Resource/filter`;
    return this.request<PageListOfResourceItemDto>('post', url, data);
  }

  /**
   * 获取关联的选项
   */
  getSelectionData(): Observable<ResourceSelectDataDto> {
    const url = `/api/Resource/selection`;
    return this.request<ResourceSelectDataDto>('get', url);
  }

  /**
   * getAllResources
   */
  getAllResources(): Observable<Resource[]> {
    const url = `/api/Resource`;
    return this.request<Resource[]>('get', url);
  }

  /**
   * 新增
   * @param data ResourceAddDto
   */
  add(data: ResourceAddDto): Observable<Resource> {
    const url = `/api/Resource`;
    return this.request<Resource>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data ResourceUpdateDto
   */
  update(id: string, data: ResourceUpdateDto): Observable<Resource> {
    const url = `/api/Resource/${id}`;
    return this.request<Resource>('put', url, data);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Resource> {
    const url = `/api/Resource/${id}`;
    return this.request<Resource>('get', url);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<Resource> {
    const url = `/api/Resource/${id}`;
    return this.request<Resource>('delete', url);
  }

}
