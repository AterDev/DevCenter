import { Status } from '../enum/status.model';
/**
 * 代码片段
 */
export interface CodeSnippetItemDto {
  name: string;
  description?: string | null;
  format: string;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
