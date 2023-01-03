import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { CodeFolderFilterDto } from '../models/code-folder/code-folder-filter-dto.model';
import { CodeFolderAddDto } from '../models/code-folder/code-folder-add-dto.model';
import { CodeFolderUpdateDto } from '../models/code-folder/code-folder-update-dto.model';
import { PageListOfCodeFolderItemDto } from '../models/code-folder/page-list-of-code-folder-item-dto.model';
import { CodeFolder } from '../models/code-folder/code-folder.model';

/**
 * 代码目录
 */
@Injectable({ providedIn: 'root' })
export class CodeFolderService extends BaseService {
  /**
   * 分页筛选
   * @param data CodeFolderFilterDto
   */
  filter(data: CodeFolderFilterDto): Observable<PageListOfCodeFolderItemDto> {
    const url = `/api/CodeFolder/filter`;
    return this.request<PageListOfCodeFolderItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data CodeFolderAddDto
   */
  add(data: CodeFolderAddDto): Observable<CodeFolder> {
    const url = `/api/CodeFolder`;
    return this.request<CodeFolder>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data CodeFolderUpdateDto
   */
  update(id: string, data: CodeFolderUpdateDto): Observable<CodeFolder> {
    const url = `/api/CodeFolder/${id}`;
    return this.request<CodeFolder>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/CodeFolder/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<CodeFolder> {
    const url = `/api/CodeFolder/${id}`;
    return this.request<CodeFolder>('get', url);
  }

}
