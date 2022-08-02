import { Status } from '../enum/status.model';
export interface BlogCatalogItemDto {
  name: string;
  type?: string | null;
  sort: number;
  level: number;
  parentId?: string | null;
  id: string;
  createdTime: Date;
  updatedTime: Date;
  /**
   * 0 = Default
1 = Deleted
2 = Invalid
3 = Valid
   */
  status?: Status | null;
  isDeleted: boolean;

}
