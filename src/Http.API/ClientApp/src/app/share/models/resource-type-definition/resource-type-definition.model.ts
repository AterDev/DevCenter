import { EntityBase } from '../entity-base.model';
import { ResourceAttributeDefine } from '../resource-attribute-define/resource-attribute-define.model';
import { Resource } from '../resource/resource.model';
export interface ResourceTypeDefinition extends EntityBase {
  name: string;
  description?: string | null;
  icon?: string | null;
  color?: string | null;
  attributeDefines?: ResourceAttributeDefine[] | null;
  resources?: Resource[] | null;

}
