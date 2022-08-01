import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { BlogTagFilterDto } from '../models/blog-tag/blog-tag-filter-dto.model';
import { BlogTagAddDto } from '../models/blog-tag/blog-tag-add-dto.model';
import { BlogTagUpdateDto } from '../models/blog-tag/blog-tag-update-dto.model';
import { PageListOfBlogTagItemDto } from '../models/blog-tag/page-list-of-blog-tag-item-dto.model';
import { BlogTag } from '../models/blog-tag/blog-tag.model';

/**
 * 博客标签
 */
@Injectable({ providedIn: 'root' })
export class BlogTagService extends BaseService {
  /**
   * 筛选
   * @param data BlogTagFilterDto
   */
  filter(data: BlogTagFilterDto): Observable<PageListOfBlogTagItemDto> {
    const url = `/api/BlogTag/filter`;
    return this.request<PageListOfBlogTagItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data BlogTagAddDto
   */
  add(data: BlogTagAddDto): Observable<BlogTag> {
    const url = `/api/BlogTag`;
    return this.request<BlogTag>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data BlogTagUpdateDto
   */
  update(id: string, data: BlogTagUpdateDto): Observable<BlogTag> {
    const url = `/api/BlogTag/${id}`;
    return this.request<BlogTag>('put', url, data);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<BlogTag> {
    const url = `/api/BlogTag/${id}`;
    return this.request<BlogTag>('get', url);
  }

}
