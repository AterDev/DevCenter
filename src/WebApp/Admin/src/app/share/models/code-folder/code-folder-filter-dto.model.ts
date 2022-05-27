import { FilterBase } from '../filter-base.model';
export interface CodeFolderFilterDto extends FilterBase {
  name?: string | null;
  parentId?: string | null;

}
