import { Status } from '../enum/status.model';
/**
 * 可配置的选项
 */
export interface ConfigOptionItemDto {
  name: string;
  displayValue?: string | null;
  value: string;
  minValue?: string | null;
  maxValue?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
