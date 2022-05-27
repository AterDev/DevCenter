import { Status } from '../enum/status.model';
/**
 * 资源组
 */
export interface ResourceGroupItemDto {
  name: string;
  /**
   * 描述
   */
  descriptioin?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
