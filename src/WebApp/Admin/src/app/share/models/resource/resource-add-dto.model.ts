import { ResourceAttribute } from '../resource-attribute/resource-attribute.model';
/**
 * 资源
 */
export interface ResourceAddDto {
  name: string;
  description?: string | null;
  /**
   * 资源类型id
   */
  resourceTypeId: string;
  /**
   * 资源组
   */
  groupId: string;
  /**
   * 包含属性
   */
  attributes?: ResourceAttribute[] | null;
  /**
   * 标签id
   */
  tagIds?: string[] | null;

}
