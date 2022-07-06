/**
 * 角色列表元素
 */
export interface RoleItemDto {
  /**
   * 角色名称
   */
  name: string;
  identifyName: string;
  description?: string | null;
  id: string;

}
