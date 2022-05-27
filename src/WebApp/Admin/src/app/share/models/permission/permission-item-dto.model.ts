import { Status } from '../enum/status.model';
/**
 * 权限列表元素
 */
export interface PermissionItemDto {
  name: string;
  /**
   * 权限路径
   */
  permissionPath?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
