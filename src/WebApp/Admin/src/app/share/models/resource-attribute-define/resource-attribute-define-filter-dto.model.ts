import { FilterBase } from '../filter-base.model';
export interface ResourceAttributeDefineFilterDto extends FilterBase {
  displayName?: string | null;
  name?: string | null;
  isEnable?: boolean | null;
  /**
   * 是否必须
   */
  required?: boolean | null;
  typeId?: string | null;

}
