import { FilterBase } from '../filter-base.model';
export interface CommentFilterDto extends FilterBase {
  blogId?: string | null;
  userId?: string | null;

}
