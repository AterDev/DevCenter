import { ResourceAttributeAddDto } from '../resource-attribute/resource-attribute-add-dto.model';
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
  attributeAddItem?: ResourceAttributeAddDto[] | null;
  /**
   * 标签id
   */
  tagIds?: string[] | null;

}
