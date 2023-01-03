import { Status } from '../enum/status.model';
/**
 * 博客标签列表元素
 */
export interface BlogTagItemDto {
  name: string;
  color?: string | null;
  icon?: string | null;
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
