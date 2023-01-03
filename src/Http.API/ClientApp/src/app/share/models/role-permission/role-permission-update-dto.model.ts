import { PermissionType } from '../enum/permission-type.model';
import { Status } from '../enum/status.model';
/**
 * 角色权限中间更新时请求结构
 */
export interface RolePermissionUpdateDto {
  roleId?: string | null;
  permissionId?: string | null;
  /**
   * 权限类型
   */
  permissionTypeMyProperty?: PermissionType | null;
  /**
   * 状态
   */
  status?: Status | null;

}
