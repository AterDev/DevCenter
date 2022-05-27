import { Status } from '../enum/status.model';
/**
 * 资源标识 
 */
export interface ResourceTagsAddDto {
  name: string;
  color?: string | null;
  /**
   * 状态
   */
  status?: Status;

}
