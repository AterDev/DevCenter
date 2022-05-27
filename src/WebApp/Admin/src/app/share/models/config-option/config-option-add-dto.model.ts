import { Status } from '../enum/status.model';
/**
 * 可配置的选项
 */
export interface ConfigOptionAddDto {
  name: string;
  displayValue?: string | null;
  value: string;
  minValue?: string | null;
  maxValue?: string | null;
  /**
   * 状态
   */
  status?: Status;
  typeId: string;

}
