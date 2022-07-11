import { Status } from '../enum/status.model';
import { LayoutType } from '../enum/layout-type.model';
import { NavigationType } from '../enum/navigation-type.model';
/**
 * 资源组
 */
export interface ResourceGroupUpdateDto {
  name?: string | null;
  /**
   * 描述
   */
  descriptioin?: string | null;
  /**
   * 状态
   */
  status?: Status | null;
  /**
   * 排序
   */
  sort?: number | null;
  /**
   * 展示类型
   */
  layoutType?: LayoutType | null;
  /**
   * 所属导航类型
   */
  navigation?: NavigationType | null;
  environmentId?: string | null;

}
