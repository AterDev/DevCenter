import { Status } from '../enum/status.model';
/**
 * 环境
 */
export interface EnvironmentItemDto {
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
