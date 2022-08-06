import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ResourceTypeDefinitionFilterDto } from '../models/resource-type-definition/resource-type-definition-filter-dto.model';
import { ResourceTypeDefinitionAddDto } from '../models/resource-type-definition/resource-type-definition-add-dto.model';
import { ResourceTypeDefinitionUpdateDto } from '../models/resource-type-definition/resource-type-definition-update-dto.model';
import { PageListOfResourceTypeDefinitionItemDto } from '../models/resource-type-definition/page-list-of-resource-type-definition-item-dto.model';
import { ResourceTypeDefinition } from '../models/resource-type-definition/resource-type-definition.model';

/**
 * 资源类型的定义
 */
@Injectable({ providedIn: 'root' })
export class ResourceTypeDefinitionService extends BaseService {
  /**
   * 筛选
   * @param data ResourceTypeDefinitionFilterDto
   */
  filter(data: ResourceTypeDefinitionFilterDto): Observable<PageListOfResourceTypeDefinitionItemDto> {
    const url = `/api/ResourceTypeDefinition/filter`;
    return this.request<PageListOfResourceTypeDefinitionItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data ResourceTypeDefinitionAddDto
   */
  add(data: ResourceTypeDefinitionAddDto): Observable<ResourceTypeDefinition> {
    const url = `/api/ResourceTypeDefinition`;
    return this.request<ResourceTypeDefinition>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data ResourceTypeDefinitionUpdateDto
   */
  update(id: string, data: ResourceTypeDefinitionUpdateDto): Observable<ResourceTypeDefinition> {
    const url = `/api/ResourceTypeDefinition/${id}`;
    return this.request<ResourceTypeDefinition>('put', url, data);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ResourceTypeDefinition> {
    const url = `/api/ResourceTypeDefinition/${id}`;
    return this.request<ResourceTypeDefinition>('get', url);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<ResourceTypeDefinition> {
    const url = `/api/ResourceTypeDefinition/${id}`;
    return this.request<ResourceTypeDefinition>('delete', url);
  }

}
