import { Status } from '../enum/status.model';
/**
 * 资源类型的定义
 */
export interface ResourceTypeDefinitionItemDto {
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
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
