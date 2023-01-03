import { Status } from '../enum/status.model';
/**
 * 权限更新时请求结构
 */
export interface PermissionUpdateDto {
  name?: string | null;
  /**
   * 权限路径
   */
  permissionPath?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
