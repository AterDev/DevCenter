import { FilterBase } from '../filter-base.model';
export interface PermissionFilterDto extends FilterBase {
  name?: string | null;
  parentId?: string | null;

}
