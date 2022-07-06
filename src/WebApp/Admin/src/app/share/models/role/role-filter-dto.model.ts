import { FilterBase } from '../filter-base.model';
export interface RoleFilterDto extends FilterBase {
  /**
   * 角色名称
   */
  name?: string | null;
  identifyName?: string | null;

}
