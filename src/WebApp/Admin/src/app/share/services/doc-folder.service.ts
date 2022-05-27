import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { DocFolderFilterDto } from '../models/doc-folder/doc-folder-filter-dto.model';
import { DocFolderAddDto } from '../models/doc-folder/doc-folder-add-dto.model';
import { DocFolderUpdateDto } from '../models/doc-folder/doc-folder-update-dto.model';
import { PageResultOfDocFolderItemDto } from '../models/doc-folder/page-result-of-doc-folder-item-dto.model';
import { DocFolder } from '../models/doc-folder/doc-folder.model';

/**
 * 文档目录
 */
@Injectable({ providedIn: 'root' })
export class DocFolderService extends BaseService {
  /**
   * 分页筛选
   * @param data DocFolderFilterDto
   */
  filter(data: DocFolderFilterDto): Observable<PageResultOfDocFolderItemDto> {
    const url = `/api/DocFolder/filter`;
    return this.request<PageResultOfDocFolderItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data DocFolderAddDto
   */
  add(data: DocFolderAddDto): Observable<DocFolder> {
    const url = `/api/DocFolder`;
    return this.request<DocFolder>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data DocFolderUpdateDto
   */
  update(id: string, data: DocFolderUpdateDto): Observable<DocFolder> {
    const url = `/api/DocFolder/${id}`;
    return this.request<DocFolder>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/DocFolder/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<DocFolder> {
    const url = `/api/DocFolder/${id}`;
    return this.request<DocFolder>('get', url);
  }

}
