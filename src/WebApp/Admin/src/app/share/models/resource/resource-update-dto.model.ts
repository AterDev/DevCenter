import { Status } from '../enum/status.model';
import { ResourceAttribute } from '../resource-attribute/resource-attribute.model';
/**
 * 资源
 */
export interface ResourceUpdateDto {
  name?: string | null;
  description?: string | null;
  /**
   * 状态
   */
  status?: Status | null;
  resourceTypeId?: string | null;
  groupId?: string | null;
  /**
   * 包含属性
   */
  attributes?: ResourceAttribute[] | null;
  /**
   * 标签id
   */
  tagIds?: string[] | null;

}
