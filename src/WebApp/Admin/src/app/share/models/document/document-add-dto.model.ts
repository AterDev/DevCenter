import { Status } from '../enum/status.model';
/**
 * 文档管理
 */
export interface DocumentAddDto {
  /**
   * 文件名
   */
  fileName: string;
  /**
   * 文件类型
   */
  ext: string;
  /**
   * 文件路径
   */
  filePath: string;
  /**
   * 状态
   */
  status?: Status;
  folderId: string;

}
