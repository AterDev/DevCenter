import { EntityBase } from '../entity-base.model';
import { Resource } from '../resource/resource.model';
export interface ResourceTags extends EntityBase {
  name: string;
  color?: string | null;
  icon?: string | null;
  resources?: Resource[] | null;

}
