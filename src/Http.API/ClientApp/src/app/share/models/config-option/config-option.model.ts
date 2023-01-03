import { EntityBase } from '../entity-base.model';
import { ValueType } from '../enum/value-type.model';
export interface ConfigOption extends EntityBase {
  name: string;
  /**
   * 0 = Default
1 = String
2 = Long
3 = Boolean
4 = Double
5 = Datetime
6 = Json
   */
  type?: ValueType | null;
  displayValue?: string | null;
  value: string;
  minValue?: string | null;
  maxValue?: string | null;

}
