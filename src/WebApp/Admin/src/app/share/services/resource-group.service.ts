import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ResourceGroupFilterDto } from '../models/resource-group/resource-group-filter-dto.model';
import { ResourceGroupAddDto } from '../models/resource-group/resource-group-add-dto.model';
import { ResourceGroupUpdateDto } from '../models/resource-group/resource-group-update-dto.model';
import { PageResultOfResourceGroupItemDto } from '../models/resource-group/page-result-of-resource-group-item-dto.model';
import { ResourceGroup } from '../models/resource-group/resource-group.model';

/**
 * 资源组
 */
@Injectable({ providedIn: 'root' })
export class ResourceGroupService extends BaseService {
  /**
   * 分页筛选
   * @param data ResourceGroupFilterDto
   */
  filter(data: ResourceGroupFilterDto): Observable<PageResultOfResourceGroupItemDto> {
    const url = `/api/ResourceGroup/filter`;
    return this.request<PageResultOfResourceGroupItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data ResourceGroupAddDto
   */
  add(data: ResourceGroupAddDto): Observable<ResourceGroup> {
    const url = `/api/ResourceGroup`;
    return this.request<ResourceGroup>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ResourceGroupUpdateDto
   */
  update(id: string, data: ResourceGroupUpdateDto): Observable<ResourceGroup> {
    const url = `/api/ResourceGroup/${id}`;
    return this.request<ResourceGroup>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/ResourceGroup/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ResourceGroup> {
    const url = `/api/ResourceGroup/${id}`;
    return this.request<ResourceGroup>('get', url);
  }

}