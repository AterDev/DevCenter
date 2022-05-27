import { Status } from '../enum/status.model';
/**
 * 资源属性值 
 */
export interface ResourceAttributeAddDto {
  displayName: string;
  name: string;
  isEnable: boolean;
  value: string;
  /**
   * 排序 
   */
  sort: number;
  /**
   * 状态
   */
  status?: Status;
  typeId: string;
  resourceId: string;

}
