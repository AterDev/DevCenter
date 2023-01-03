import { Status } from '../enum/status.model';
/**
 * 文档管理
 */
export interface DocumentUpdateDto {
  /**
   * 文件名
   */
  fileName?: string | null;
  /**
   * 文件类型
   */
  ext?: string | null;
  /**
   * 文件路径
   */
  filePath?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
