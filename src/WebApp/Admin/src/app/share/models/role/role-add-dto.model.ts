import { Status } from '../enum/status.model';
/**
 * 角色添加时请求结构
 */
export interface RoleAddDto {
  /**
   * 角色名称
   */
  name: string;
  /**
   * 图标
   */
  icon?: string | null;
  /**
   * 状态
   */
  status?: Status;

}
