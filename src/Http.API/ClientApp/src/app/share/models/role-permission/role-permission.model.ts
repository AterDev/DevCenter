import { EntityBase } from '../entity-base.model';
import { PermissionType } from '../enum/permission-type.model';
import { Role } from '../role/role.model';
import { Permission } from '../permission/permission.model';
export interface RolePermission extends EntityBase {
  roleId: string;
  permissionId: string;
  /**
   * 0 = Read
1 = Audit
2 = Add
3 = Edit
4 = Write
5 = AuditWrite
   */
  permissionTypeMyProperty?: PermissionType | null;
  role?: Role | null;
  permission?: Permission | null;

}
