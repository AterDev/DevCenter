import { EntityBase } from '../entity-base.model';
import { LayoutType } from '../enum/layout-type.model';
import { NavigationType } from '../enum/navigation-type.model';
import { Environment } from '../environment/environment.model';
import { Resource } from '../resource/resource.model';
import { Role } from '../role/role.model';
export interface ResourceGroup extends EntityBase {
  name: string;
  descriptioin?: string | null;
  sort: number;
  /**
   * 0 = Default
1 = Card
2 = Grid
3 = List
4 = Table
   */
  layoutType?: LayoutType | null;
  /**
   * 0 = Default
1 = WebSite
2 = Tools
3 = Server
4 = CodeSnippets
   */
  navigation?: NavigationType | null;
  environment?: Environment | null;
  resources?: Resource[] | null;
  roles?: Role[] | null;

}
