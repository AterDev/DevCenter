import { FilterBase } from '../filter-base.model';
export interface ResourceGroupFilterDto extends FilterBase {
  name?: string | null;
  environmentId?: string | null;
  roleId?: string | null;

}
