import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ErrorLoggingRequest } from '../models/web-hook-notify/error-logging-request.model';

/**
 * WebHook Notify
 */
@Injectable({ providedIn: 'root' })
export class WebHookNotifyService extends BaseService {
  /**
   * gitlab webhook 通知
   * @param subscriber string
   * @param data any
   */
  gitLabNotify(subscriber: string, data: any): Observable<FormData> {
    const url = `/api/WebHookNotify/gitlab/${subscriber}`;
    return this.request<FormData>('post', url, data);
  }

  /**
   * 错误信息
   * @param data ErrorLoggingRequest
   */
  errorNotify(data: ErrorLoggingRequest): Observable<FormData> {
    const url = `/api/WebHookNotify/exception`;
    return this.request<FormData>('post', url, data);
  }

}
