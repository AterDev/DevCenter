import { Status } from '../enum/status.model';
/**
 * 资源组
 */
export interface ResourceGroupUpdateDto {
  name?: string | null;
  /**
   * 描述
   */
  descriptioin?: string | null;
  /**
   * 状态
   */
  status?: Status | null;
  environmentId?: string | null;

}
