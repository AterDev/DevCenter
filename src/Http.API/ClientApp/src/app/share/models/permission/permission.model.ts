import { EntityBase } from '../entity-base.model';
import { Role } from '../role/role.model';
import { RolePermission } from '../role-permission/role-permission.model';
export interface Permission extends EntityBase {
  name: string;
  parent?: Permission | null;
  permissionPath?: string | null;
  roles?: Role[] | null;
  rolePermissions?: RolePermission[] | null;

}
