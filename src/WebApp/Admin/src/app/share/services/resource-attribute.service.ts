import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ResourceAttributeFilterDto } from '../models/resource-attribute/resource-attribute-filter-dto.model';
import { ResourceAttributeAddDto } from '../models/resource-attribute/resource-attribute-add-dto.model';
import { ResourceAttributeUpdateDto } from '../models/resource-attribute/resource-attribute-update-dto.model';
import { PageResultOfResourceAttributeItemDto } from '../models/resource-attribute/page-result-of-resource-attribute-item-dto.model';
import { ResourceAttribute } from '../models/resource-attribute/resource-attribute.model';

/**
 * 资源属性值 
 */
@Injectable({ providedIn: 'root' })
export class ResourceAttributeService extends BaseService {
  /**
   * 分页筛选
   * @param data ResourceAttributeFilterDto
   */
  filter(data: ResourceAttributeFilterDto): Observable<PageResultOfResourceAttributeItemDto> {
    const url = `/api/ResourceAttribute/filter`;
    return this.request<PageResultOfResourceAttributeItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data ResourceAttributeAddDto
   */
  add(data: ResourceAttributeAddDto): Observable<ResourceAttribute> {
    const url = `/api/ResourceAttribute`;
    return this.request<ResourceAttribute>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ResourceAttributeUpdateDto
   */
  update(id: string, data: ResourceAttributeUpdateDto): Observable<ResourceAttribute> {
    const url = `/api/ResourceAttribute/${id}`;
    return this.request<ResourceAttribute>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/ResourceAttribute/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ResourceAttribute> {
    const url = `/api/ResourceAttribute/${id}`;
    return this.request<ResourceAttribute>('get', url);
  }

}
