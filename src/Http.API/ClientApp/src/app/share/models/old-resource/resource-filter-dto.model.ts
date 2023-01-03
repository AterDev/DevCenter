import { FilterBase } from '../filter-base.model';
export interface ResourceFilterDto extends FilterBase {
  name?: string | null;
  resourceTypeId?: string | null;
  groupId?: string | null;

}
