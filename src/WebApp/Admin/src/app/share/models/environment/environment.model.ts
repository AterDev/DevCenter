import { EntityBase } from '../entity-base.model';
import { ResourceGroup } from '../resource-group/resource-group.model';
export interface Environment extends EntityBase {
  name: string;
  description?: string | null;
  color?: string | null;
  resourceGroups?: ResourceGroup[] | null;

}
