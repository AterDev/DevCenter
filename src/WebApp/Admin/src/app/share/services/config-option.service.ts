import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ConfigOptionFilterDto } from '../models/config-option/config-option-filter-dto.model';
import { ConfigOptionAddDto } from '../models/config-option/config-option-add-dto.model';
import { ConfigOptionUpdateDto } from '../models/config-option/config-option-update-dto.model';
import { PageResultOfConfigOptionItemDto } from '../models/config-option/page-result-of-config-option-item-dto.model';
import { ConfigOption } from '../models/config-option/config-option.model';

/**
 * 可配置的选项
 */
@Injectable({ providedIn: 'root' })
export class ConfigOptionService extends BaseService {
  /**
   * 分页筛选
   * @param data ConfigOptionFilterDto
   */
  filter(data: ConfigOptionFilterDto): Observable<PageResultOfConfigOptionItemDto> {
    const url = `/api/ConfigOption/filter`;
    return this.request<PageResultOfConfigOptionItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data ConfigOptionAddDto
   */
  add(data: ConfigOptionAddDto): Observable<ConfigOption> {
    const url = `/api/ConfigOption`;
    return this.request<ConfigOption>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ConfigOptionUpdateDto
   */
  update(id: string, data: ConfigOptionUpdateDto): Observable<ConfigOption> {
    const url = `/api/ConfigOption/${id}`;
    return this.request<ConfigOption>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/ConfigOption/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ConfigOption> {
    const url = `/api/ConfigOption/${id}`;
    return this.request<ConfigOption>('get', url);
  }

}
