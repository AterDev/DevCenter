import { Status } from '../enum/status.model';
/**
 * 资源标识 
 */
export interface ResourceTagsUpdateDto {
  name?: string | null;
  color?: string | null;
  icon?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
