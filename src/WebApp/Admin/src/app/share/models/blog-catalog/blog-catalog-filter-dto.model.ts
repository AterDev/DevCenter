import { FilterBase } from '../filter-base.model';
export interface BlogCatalogFilterDto extends FilterBase {
  name?: string | null;
  sort?: number | null;
  level?: number | null;
  parentId?: string | null;

}
