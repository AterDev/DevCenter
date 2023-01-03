import { FilterBase } from '../filter-base.model';
export interface DocFolderFilterDto extends FilterBase {
  name?: string | null;
  parentId?: string | null;

}
