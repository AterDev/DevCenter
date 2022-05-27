import { EntityBase } from '../entity-base.model';
import { ValueType } from '../enum/value-type.model';
import { Resource } from '../resource/resource.model';
export interface ResourceAttribute extends EntityBase {
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
  value: string;
  sort: number;
  resource?: Resource | null;

}
