import { Status } from '../enum/status.model';
/**
 * 代码片段
 */
export interface CodeSnippetUpdateDto {
  name?: string | null;
  description?: string | null;
  format?: string | null;
  content?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
