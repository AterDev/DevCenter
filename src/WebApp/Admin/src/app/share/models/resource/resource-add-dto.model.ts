import { Status } from '../enum/status.model';
/**
 * 资源
 */
export interface ResourceAddDto {
  name: string;
  description?: string | null;
  /**
   * 状态
   */
  status?: Status;
  resourceTypeId: string;
  groupId: string;

}
