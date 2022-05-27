import { EntityBase } from '../entity-base.model';
import { Environment } from '../environment/environment.model';
import { Resource } from '../resource/resource.model';
export interface ResourceGroup extends EntityBase {
  name: string;
  descriptioin?: string | null;
  environment?: Environment | null;
  resources?: Resource[] | null;

}