/**
 * 资源属性定义
 */
export interface ResourceAttributeDefineItemDto {
  displayName: string;
  name: string;
  isEnable: boolean;
  /**
   * 是否必须
   */
  required: boolean;
  /**
   * 排序 
   */
  sort: number;
  id: string;
  createdTime: Date;

}
