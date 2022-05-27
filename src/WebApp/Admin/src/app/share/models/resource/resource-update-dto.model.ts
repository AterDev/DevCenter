import { Status } from '../enum/status.model';
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

}
