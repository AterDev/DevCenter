import { FilterBase } from '../filter-base.model';
export interface CodeLibraryFilterDto extends FilterBase {
  /**
   * 库命名空间
   */
  namespace?: string | null;
  /**
   * 是否有效
   */
  isValid?: boolean | null;
  /**
   * 是否公开
   */
  isPublic?: boolean | null;
  userId?: string | null;

}
