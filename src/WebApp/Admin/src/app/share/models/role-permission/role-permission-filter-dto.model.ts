import { FilterBase } from '../filter-base.model';
import { PermissionType } from '../enum/permission-type.model';
export interface RolePermissionFilterDto extends FilterBase {
  roleId?: string | null;
  permissionId?: string | null;
  /**
   * 权限类型
   */
  permissionTypeMyProperty?: PermissionType | null;

}
