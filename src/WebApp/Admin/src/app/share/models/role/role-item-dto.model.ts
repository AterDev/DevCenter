import { Status } from '../enum/status.model';
/**
 * 角色列表元素
 */
export interface RoleItemDto {
  /**
   * 角色名称
   */
  name: string;
  /**
   * 图标
   */
  icon?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
