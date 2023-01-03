import { FilterBase } from '../filter-base.model';
export interface BlogTagFilterDto extends FilterBase {
  name?: string | null;

}
