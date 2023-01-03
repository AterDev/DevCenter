import { FilterBase } from '../filter-base.model';
export interface ResourceAttributeFilterDto extends FilterBase {
  displayName?: string | null;
  name?: string | null;
  isEnable?: boolean | null;
  value?: string | null;
  /**
   * 排序 
   */
  sort?: number | null;
  typeId?: string | null;
  resourceId?: string | null;

}
