import { EntityBase } from '../entity-base.model';
import { User } from '../user/user.model';
import { Permission } from '../permission/permission.model';
import { ResourceGroup } from '../resource-group/resource-group.model';
export interface Role extends EntityBase {
  name: string;
  identifyName: string;
  description?: string | null;
  icon?: string | null;
  users?: User[] | null;
  permissions?: Permission[] | null;
  resourceGroups?: ResourceGroup[] | null;

}
