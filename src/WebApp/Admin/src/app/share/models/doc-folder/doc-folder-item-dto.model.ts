import { Status } from '../enum/status.model';
/**
 * 文档目录
 */
export interface DocFolderItemDto {
  name: string;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
