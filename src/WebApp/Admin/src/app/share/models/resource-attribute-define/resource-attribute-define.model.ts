import { EntityBase } from '../entity-base.model';
import { ValueType } from '../enum/value-type.model';
export interface ResourceAttributeDefine extends EntityBase {
  displayName: string;
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
  isEnable: boolean;
  required: boolean;
  sort: number;

}
