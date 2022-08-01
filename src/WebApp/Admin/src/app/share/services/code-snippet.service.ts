import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { CodeSnippetFilterDto } from '../models/code-snippet/code-snippet-filter-dto.model';
import { CodeSnippetAddDto } from '../models/code-snippet/code-snippet-add-dto.model';
import { CodeSnippetUpdateDto } from '../models/code-snippet/code-snippet-update-dto.model';
import { PageListOfCodeSnippetItemDto } from '../models/code-snippet/page-list-of-code-snippet-item-dto.model';
import { CodeSnippet } from '../models/code-snippet/code-snippet.model';

/**
 * 代码片段
 */
@Injectable({ providedIn: 'root' })
export class CodeSnippetService extends BaseService {
  /**
   * 筛选
   * @param data CodeSnippetFilterDto
   */
  filter(data: CodeSnippetFilterDto): Observable<PageListOfCodeSnippetItemDto> {
    const url = `/api/CodeSnippet/filter`;
    return this.request<PageListOfCodeSnippetItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data CodeSnippetAddDto
   */
  add(data: CodeSnippetAddDto): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet`;
    return this.request<CodeSnippet>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data CodeSnippetUpdateDto
   */
  update(id: string, data: CodeSnippetUpdateDto): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet/${id}`;
    return this.request<CodeSnippet>('put', url, data);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<CodeSnippet> {
    const url = `/api/CodeSnippet/${id}`;
    return this.request<CodeSnippet>('get', url);
  }

}
