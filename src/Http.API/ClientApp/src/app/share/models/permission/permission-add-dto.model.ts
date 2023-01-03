import { Status } from '../enum/status.model';
/**
 * 权限添加时请求结构
 */
export interface PermissionAddDto {
  name: string;
  /**
   * 权限路径
   */
  permissionPath?: string | null;
  /**
   * 状态
   */
  status?: Status;
  parentId: string;

}
