import { Status } from '../enum/status.model';
/**
 * 可配置的选项
 */
export interface ConfigOptionUpdateDto {
  name?: string | null;
  displayValue?: string | null;
  value?: string | null;
  minValue?: string | null;
  maxValue?: string | null;
  /**
   * 状态
   */
  status?: Status | null;
  typeId?: string | null;

}
