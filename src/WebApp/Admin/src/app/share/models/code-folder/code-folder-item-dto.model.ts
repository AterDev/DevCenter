import { Status } from '../enum/status.model';
/**
 * 代码目录
 */
export interface CodeFolderItemDto {
  name: string;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
