import { PermissionType } from '../enum/permission-type.model';
import { Status } from '../enum/status.model';
/**
 * 角色权限中间添加时请求结构
 */
export interface RolePermissionAddDto {
  roleId: string;
  permissionId: string;
  /**
   * 权限类型
   */
  permissionTypeMyProperty?: PermissionType;
  /**
   * 状态
   */
  status?: Status;

}
