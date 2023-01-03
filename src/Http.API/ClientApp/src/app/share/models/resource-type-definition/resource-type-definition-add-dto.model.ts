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
   * 包含的属性定义
   */
  attributeDefineIds?: string[] | null;

}
