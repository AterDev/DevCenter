import { Status } from '../enum/status.model';
/**
 * 代码目录
 */
export interface CodeFolderAddDto {
  name: string;
  /**
   * 状态
   */
  status?: Status;
  parentId: string;

}
