import { EntityBase } from '../entity-base.model';
import { ResourceTypeDefinition } from '../resource-type-definition/resource-type-definition.model';
import { ResourceAttribute } from '../resource-attribute/resource-attribute.model';
import { ResourceGroup } from '../resource-group/resource-group.model';
import { ResourceTags } from '../resource-tags/resource-tags.model';
export interface Resource extends EntityBase {
  name: string;
  description?: string | null;
  resourceType?: ResourceTypeDefinition | null;
  attributes?: ResourceAttribute[] | null;
  group?: ResourceGroup | null;
  tags?: ResourceTags[] | null;

}
