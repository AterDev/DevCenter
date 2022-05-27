import { Status } from '../enum/status.model';
/**
 * 文档目录
 */
export interface DocFolderUpdateDto {
  name?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
