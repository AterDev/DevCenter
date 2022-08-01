import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { CommentFilterDto } from '../models/comment/comment-filter-dto.model';
import { CommentAddDto } from '../models/comment/comment-add-dto.model';
import { CommentUpdateDto } from '../models/comment/comment-update-dto.model';
import { PageListOfCommentItemDto } from '../models/comment/page-list-of-comment-item-dto.model';
import { Comment } from '../models/comment/comment.model';

/**
 * 博客评论
 */
@Injectable({ providedIn: 'root' })
export class CommentService extends BaseService {
  /**
   * 筛选
   * @param data CommentFilterDto
   */
  filter(data: CommentFilterDto): Observable<PageListOfCommentItemDto> {
    const url = `/api/Comment/filter`;
    return this.request<PageListOfCommentItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data CommentAddDto
   */
  add(data: CommentAddDto): Observable<Comment> {
    const url = `/api/Comment`;
    return this.request<Comment>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data CommentUpdateDto
   */
  update(id: string, data: CommentUpdateDto): Observable<Comment> {
    const url = `/api/Comment/${id}`;
    return this.request<Comment>('put', url, data);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<Comment> {
    const url = `/api/Comment/${id}`;
    return this.request<Comment>('get', url);
  }

}
