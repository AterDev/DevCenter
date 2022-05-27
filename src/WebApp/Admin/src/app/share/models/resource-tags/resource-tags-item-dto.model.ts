import { Status } from '../enum/status.model';
/**
 * 资源标识 
 */
export interface ResourceTagsItemDto {
  name: string;
  color?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
