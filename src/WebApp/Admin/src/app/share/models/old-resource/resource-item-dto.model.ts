import { Status } from '../enum/status.model';
/**
 * 资源
 */
export interface ResourceItemDto {
  name: string;
  description?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
