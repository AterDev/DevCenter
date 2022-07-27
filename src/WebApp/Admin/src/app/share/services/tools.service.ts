import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { SSHOption } from '../models/tools/sshoption.model';

/**
 * 工具集
 */
@Injectable({ providedIn: 'root' })
export class ToolsService extends BaseService {
  /**
   * generateCIYml
   * @param data SSHOption
   */
  generateCIYml(data: SSHOption): Observable<string> {
    const url = `/api/Tools/GitLabCIGenerator`;
    return this.request<string>('post', url, data);
  }

}
