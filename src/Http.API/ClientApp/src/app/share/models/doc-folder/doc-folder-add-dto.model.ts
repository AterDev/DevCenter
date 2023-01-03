import { Status } from '../enum/status.model';
/**
 * 文档目录
 */
export interface DocFolderAddDto {
  name: string;
  /**
   * 状态
   */
  status?: Status;
  parentId: string;

}
