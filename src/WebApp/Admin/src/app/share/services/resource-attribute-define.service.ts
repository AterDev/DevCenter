import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ResourceAttributeDefineFilterDto } from '../models/resource-attribute-define/resource-attribute-define-filter-dto.model';
import { ResourceAttributeDefineAddDto } from '../models/resource-attribute-define/resource-attribute-define-add-dto.model';
import { ResourceAttributeDefineUpdateDto } from '../models/resource-attribute-define/resource-attribute-define-update-dto.model';
import { PageResultOfResourceAttributeDefineItemDto } from '../models/resource-attribute-define/page-result-of-resource-attribute-define-item-dto.model';
import { ResourceAttributeDefine } from '../models/resource-attribute-define/resource-attribute-define.model';

/**
 * 资源属性定义
 */
@Injectable({ providedIn: 'root' })
export class ResourceAttributeDefineService extends BaseService {
  /**
   * 分页筛选
   * @param data ResourceAttributeDefineFilterDto
   */
  filter(data: ResourceAttributeDefineFilterDto): Observable<PageResultOfResourceAttributeDefineItemDto> {
    const url = `/api/ResourceAttributeDefine/filter`;
    return this.request<PageResultOfResourceAttributeDefineItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data ResourceAttributeDefineAddDto
   */
  add(data: ResourceAttributeDefineAddDto): Observable<ResourceAttributeDefine> {
    const url = `/api/ResourceAttributeDefine`;
    return this.request<ResourceAttributeDefine>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ResourceAttributeDefineUpdateDto
   */
  update(id: string, data: ResourceAttributeDefineUpdateDto): Observable<ResourceAttributeDefine> {
    const url = `/api/ResourceAttributeDefine/${id}`;
    return this.request<ResourceAttributeDefine>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/ResourceAttributeDefine/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ResourceAttributeDefine> {
    const url = `/api/ResourceAttributeDefine/${id}`;
    return this.request<ResourceAttributeDefine>('get', url);
  }

}
