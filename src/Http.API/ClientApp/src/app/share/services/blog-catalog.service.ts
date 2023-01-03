import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { BlogCatalogFilterDto } from '../models/blog-catalog/blog-catalog-filter-dto.model';
import { BlogCatalogAddDto } from '../models/blog-catalog/blog-catalog-add-dto.model';
import { BlogCatalogUpdateDto } from '../models/blog-catalog/blog-catalog-update-dto.model';
import { PageListOfBlogCatalogItemDto } from '../models/blog-catalog/page-list-of-blog-catalog-item-dto.model';
import { BlogCatalog } from '../models/blog-catalog/blog-catalog.model';

/**
 * 博客目录
 */
@Injectable({ providedIn: 'root' })
export class BlogCatalogService extends BaseService {
  /**
   * 筛选
   * @param data BlogCatalogFilterDto
   */
  filter(data: BlogCatalogFilterDto): Observable<PageListOfBlogCatalogItemDto> {
    const url = `/api/BlogCatalog/filter`;
    return this.request<PageListOfBlogCatalogItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data BlogCatalogAddDto
   */
  add(data: BlogCatalogAddDto): Observable<BlogCatalog> {
    const url = `/api/BlogCatalog`;
    return this.request<BlogCatalog>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data BlogCatalogUpdateDto
   */
  update(id: string, data: BlogCatalogUpdateDto): Observable<BlogCatalog> {
    const url = `/api/BlogCatalog/${id}`;
    return this.request<BlogCatalog>('put', url, data);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<BlogCatalog> {
    const url = `/api/BlogCatalog/${id}`;
    return this.request<BlogCatalog>('get', url);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<BlogCatalog> {
    const url = `/api/BlogCatalog/${id}`;
    return this.request<BlogCatalog>('delete', url);
  }

}
