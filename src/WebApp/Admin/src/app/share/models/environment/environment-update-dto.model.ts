import { Status } from '../enum/status.model';
/**
 * 环境
 */
export interface EnvironmentUpdateDto {
  name?: string | null;
  description?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
