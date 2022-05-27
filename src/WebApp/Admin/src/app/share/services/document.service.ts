import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { DocumentFilterDto } from '../models/document/document-filter-dto.model';
import { DocumentAddDto } from '../models/document/document-add-dto.model';
import { DocumentUpdateDto } from '../models/document/document-update-dto.model';
import { PageResultOfDocumentItemDto } from '../models/document/page-result-of-document-item-dto.model';
import { Document } from '../models/document/document.model';

/**
 * 文档管理
 */
@Injectable({ providedIn: 'root' })
export class DocumentService extends BaseService {
  /**
   * 分页筛选
   * @param data DocumentFilterDto
   */
  filter(data: DocumentFilterDto): Observable<PageResultOfDocumentItemDto> {
    const url = `/api/Document/filter`;
    return this.request<PageResultOfDocumentItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data DocumentAddDto
   */
  add(data: DocumentAddDto): Observable<Document> {
    const url = `/api/Document`;
    return this.request<Document>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data DocumentUpdateDto
   */
  update(id: string, data: DocumentUpdateDto): Observable<Document> {
    const url = `/api/Document/${id}`;
    return this.request<Document>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/Document/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Document> {
    const url = `/api/Document/${id}`;
    return this.request<Document>('get', url);
  }

}
