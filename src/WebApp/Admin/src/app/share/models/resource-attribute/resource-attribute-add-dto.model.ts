import { ValueType } from '../enum/value-type.model';
/**
 * 资源属性值 
 */
export interface ResourceAttributeAddDto {
  displayName: string;
  name: string;
  isEnable?: boolean | null;
  value: string;
  /**
   * 排序 
   */
  sort?: number | null;
  type?: ValueType | null;
  resourceId?: string | null;

}
