import { Status } from '../enum/status.model';
/**
 * 代码目录
 */
export interface CodeFolderUpdateDto {
  name?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
