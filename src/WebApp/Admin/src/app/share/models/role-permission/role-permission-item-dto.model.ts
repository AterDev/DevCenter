import { PermissionType } from '../enum/permission-type.model';
import { Status } from '../enum/status.model';
/**
 * 角色权限中间列表元素
 */
export interface RolePermissionItemDto {
  roleId: string;
  permissionId: string;
  /**
   * 权限类型
   */
  permissionTypeMyProperty?: PermissionType;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
