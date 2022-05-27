import { Status } from './enum/status.model';
export interface EntityBase {
  id: string;
  /**
   * 0 = Default
1 = Deleted
2 = Invalid
3 = Valid
   */
  status?: Status | null;
  createdTime: Date;
  updatedTime: Date;

}
