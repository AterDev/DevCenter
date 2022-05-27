import { Status } from '../enum/status.model';
/**
 * 资源属性值 
 */
export interface ResourceAttributeUpdateDto {
  displayName?: string | null;
  name?: string | null;
  isEnable?: boolean | null;
  value?: string | null;
  /**
   * 排序 
   */
  sort?: number | null;
  /**
   * 状态
   */
  status?: Status | null;
  typeId?: string | null;
  resourceId?: string | null;

}
