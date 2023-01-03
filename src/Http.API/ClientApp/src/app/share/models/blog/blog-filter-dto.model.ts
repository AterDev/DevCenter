import { FilterBase } from '../filter-base.model';
export interface BlogFilterDto extends FilterBase {
  /**
   * 标题
   */
  title?: string | null;
  userId?: string | null;
  catalogId?: string | null;

}
