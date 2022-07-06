/**
 * 角色添加时请求结构
 */
export interface RoleAddDto {
  /**
   * 角色名称
   */
  name: string;
  identifyName: string;
  description?: string | null;
  /**
   * 图标
   */
  icon?: string | null;

}
