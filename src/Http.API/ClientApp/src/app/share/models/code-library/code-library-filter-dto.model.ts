import { FilterBase } from '../filter-base.model';
import { LibraryType } from '../enum/library-type.model';
export interface CodeLibraryFilterDto extends FilterBase {
  /**
   * 库命名空间
   */
  namespace?: string | null;
  /**
   * 语言类型
   */
  type?: LibraryType | null;
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
