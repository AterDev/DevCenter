import { Status } from '../enum/status.model';
/**
 * 资源类型的定义
 */
export interface ResourceTypeDefinitionAddDto {
  name: string;
  description?: string | null;
  /**
   * 图标
   */
  icon?: string | null;
  /**
   * 颜色
   */
  color?: string | null;
  /**
   * 状态
   */
  status?: Status;

}
