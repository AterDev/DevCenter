import { Status } from '../enum/status.model';
import { ResourceAttributeAddDto } from '../old-resource/resource-attribute-add-dto.model';
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
  attributeAddItem?: ResourceAttributeAddDto[] | null;
  /**
   * 标签id
   */
  tagIds?: string[] | null;

}
