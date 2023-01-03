import { Status } from '../enum/status.model';
/**
 * 角色更新时请求结构
 */
export interface RoleUpdateDto {
  /**
   * 角色名称
   */
  name?: string | null;
  identifyName?: string | null;
  description?: string | null;
  /**
   * 图标
   */
  icon?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
