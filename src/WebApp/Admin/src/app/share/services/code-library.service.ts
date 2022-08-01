import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { CodeLibraryFilterDto } from '../models/code-library/code-library-filter-dto.model';
import { CodeLibraryAddDto } from '../models/code-library/code-library-add-dto.model';
import { CodeLibraryUpdateDto } from '../models/code-library/code-library-update-dto.model';
import { PageListOfCodeLibraryItemDto } from '../models/code-library/page-list-of-code-library-item-dto.model';
import { CodeLibrary } from '../models/code-library/code-library.model';

/**
 * 模型库
 */
@Injectable({ providedIn: 'root' })
export class CodeLibraryService extends BaseService {
  /**
   * 筛选
   * @param data CodeLibraryFilterDto
   */
  filter(data: CodeLibraryFilterDto): Observable<PageListOfCodeLibraryItemDto> {
    const url = `/api/CodeLibrary/filter`;
    return this.request<PageListOfCodeLibraryItemDto>('post', url, data);
  }

  /**
   * 新增
   * @param data CodeLibraryAddDto
   */
  add(data: CodeLibraryAddDto): Observable<CodeLibrary> {
    const url = `/api/CodeLibrary`;
    return this.request<CodeLibrary>('post', url, data);
  }

  /**
   * 更新
   * @param id string
   * @param data CodeLibraryUpdateDto
   */
  update(id: string, data: CodeLibraryUpdateDto): Observable<CodeLibrary> {
    const url = `/api/CodeLibrary/${id}`;
    return this.request<CodeLibrary>('put', url, data);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<CodeLibrary> {
    const url = `/api/CodeLibrary/${id}`;
    return this.request<CodeLibrary>('get', url);
  }

}
