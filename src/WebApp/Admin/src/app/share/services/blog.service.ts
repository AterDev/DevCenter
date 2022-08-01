import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { BlogFilterDto } from '../models/blog/blog-filter-dto.model';
import { BlogAddDto } from '../models/blog/blog-add-dto.model';
import { BlogUpdateDto } from '../models/blog/blog-update-dto.model';
import { PageListOfBlogItemDto } from '../models/blog/page-list-of-blog-item-dto.model';
import { Blog } from '../models/blog/blog.model';

/**
 * 博客
 */
@Injectable({ providedIn: 'root' })
export class BlogService extends BaseService {
  /**
   * 筛选
   * @param data BlogFilterDto
   */
  filter(data: BlogFilterDto): Observable<PageListOfBlogItemDto> {
    const url = `/api/Blog/filter`;
    return this.request<PageListOfBlogItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data BlogAddDto
   */
  add(data: BlogAddDto): Observable<Blog> {
    const url = `/api/Blog`;
    return this.request<Blog>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data BlogUpdateDto
   */
  update(id: string, data: BlogUpdateDto): Observable<Blog> {
    const url = `/api/Blog/${id}`;
    return this.request<Blog>('put', url, data);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<Blog> {
    const url = `/api/Blog/${id}`;
    return this.request<Blog>('get', url);
  }

}
