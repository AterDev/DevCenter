import { Status } from '../enum/status.model';
export interface CommentUpdateDto {
  /**
   * 评论内容
   */
  content?: string | null;
  status?: Status | null;
  isDeleted?: boolean | null;
  blogId?: string | null;
  userId?: string | null;

}
