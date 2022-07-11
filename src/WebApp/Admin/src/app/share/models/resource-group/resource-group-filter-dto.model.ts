import { FilterBase } from '../filter-base.model';
import { LayoutType } from '../enum/layout-type.model';
import { NavigationType } from '../enum/navigation-type.model';
export interface ResourceGroupFilterDto extends FilterBase {
  name?: string | null;
  /**
   * 展示类型
   */
  layoutType?: LayoutType | null;
  /**
   * 所属导航类型
   */
  navigation?: NavigationType | null;
  environmentId?: string | null;
  userId?: string | null;

}
