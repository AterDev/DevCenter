import { Status } from '../enum/status.model';
/**
 * 代码片段
 */
export interface CodeSnippetAddDto {
  name: string;
  description?: string | null;
  format: string;
  content?: string | null;
  /**
   * 状态
   */
  status?: Status;

}
