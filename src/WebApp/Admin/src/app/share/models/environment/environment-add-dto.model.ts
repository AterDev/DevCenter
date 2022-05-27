import { Status } from '../enum/status.model';
/**
 * 环境
 */
export interface EnvironmentAddDto {
  name: string;
  description?: string | null;
  /**
   * 状态
   */
  status?: Status;

}
