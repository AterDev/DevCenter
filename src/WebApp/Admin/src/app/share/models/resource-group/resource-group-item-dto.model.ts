import { LayoutType } from '../enum/layout-type.model';
import { NavigationType } from '../enum/navigation-type.model';
import { Environment } from '../environment/environment.model';
import { Resource } from '../old-resource/resource.model';
/**
 * 资源组
 */
export interface ResourceGroupItemDto {
  name: string;
  /**
   * 描述
   */
  descriptioin?: string | null;
  /**
   * 排序
   */
  sort: number;
  /**
   * 展示类型
   */
  layoutType?: LayoutType;
  /**
   * 所属导航类型
   */
  navigation?: NavigationType;
  id: string;
  environment?: Environment | null;
  resource?: Resource[];

}
