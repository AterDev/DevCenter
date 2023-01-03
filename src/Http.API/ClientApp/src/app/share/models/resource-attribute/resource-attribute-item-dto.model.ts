import { Status } from '../enum/status.model';
/**
 * 资源属性值 
 */
export interface ResourceAttributeItemDto {
  displayName: string;
  name: string;
  isEnable: boolean;
  /**
   * 排序 
   */
  sort: number;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
