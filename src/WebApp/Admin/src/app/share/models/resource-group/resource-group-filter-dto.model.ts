import { FilterBase } from '../filter-base.model';
export interface ResourceGroupFilterDto extends FilterBase {
  name?: string | null;
  environmentId?: string | null;
  userId?: string | null;

}
