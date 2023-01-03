import { Status } from '../enum/status.model';
/**
 * 博客标签更新时请求结构
 */
export interface BlogTagUpdateDto {
  name?: string | null;
  color?: string | null;
  icon?: string | null;
  status?: Status | null;
  isDeleted?: boolean | null;

}
