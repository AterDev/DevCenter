import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ResourceTagsFilterDto } from '../models/resource-tags/resource-tags-filter-dto.model';
import { ResourceTagsAddDto } from '../models/resource-tags/resource-tags-add-dto.model';
import { ResourceTagsUpdateDto } from '../models/resource-tags/resource-tags-update-dto.model';
import { PageListOfResourceTagsItemDto } from '../models/resource-tags/page-list-of-resource-tags-item-dto.model';
import { ResourceTags } from '../models/resource-tags/resource-tags.model';

/**
 * 资源标识 
 */
@Injectable({ providedIn: 'root' })
export class ResourceTagsService extends BaseService {
  /**
   * 分页筛选
   * @param data ResourceTagsFilterDto
   */
  filter(data: ResourceTagsFilterDto): Observable<PageListOfResourceTagsItemDto> {
    const url = `/api/ResourceTags/filter`;
    return this.request<PageListOfResourceTagsItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data ResourceTagsAddDto
   */
  add(data: ResourceTagsAddDto): Observable<ResourceTags> {
    const url = `/api/ResourceTags`;
    return this.request<ResourceTags>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ResourceTagsUpdateDto
   */
  update(id: string, data: ResourceTagsUpdateDto): Observable<ResourceTags> {
    const url = `/api/ResourceTags/${id}`;
    return this.request<ResourceTags>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/ResourceTags/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ResourceTags> {
    const url = `/api/ResourceTags/${id}`;
    return this.request<ResourceTags>('get', url);
  }

}
