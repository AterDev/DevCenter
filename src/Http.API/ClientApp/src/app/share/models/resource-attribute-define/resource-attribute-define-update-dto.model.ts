import { Status } from '../enum/status.model';
/**
 * 资源属性定义
 */
export interface ResourceAttributeDefineUpdateDto {
  displayName?: string | null;
  name?: string | null;
  isEnable?: boolean | null;
  /**
   * 是否必须
   */
  required?: boolean | null;
  /**
   * 排序 
   */
  sort?: number | null;
  /**
   * 状态
   */
  status?: Status | null;
  typeId?: string | null;

}
