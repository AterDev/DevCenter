import { Status } from '../enum/status.model';
/**
 * 资源组
 */
export interface ResourceGroupAddDto {
  name: string;
  /**
   * 描述
   */
  descriptioin?: string | null;
  /**
   * 状态
   */
  status?: Status;
  environmentId: string;

}
