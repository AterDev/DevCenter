import { Status } from '../enum/status.model';
/**
 * 文章内容更新时请求结构
 */
export interface BlogUpdateDto {
  /**
   * 标题
   */
  title?: string | null;
  /**
   * 概要
   */
  summary?: string | null;
  /**
   * 作者名称
   */
  authorName?: string | null;
  /**
   * 仅个人查看
   */
  isPrivate?: boolean | null;
  /**
   * 文章内容
   */
  content?: string | null;
  status?: Status | null;
  isDeleted?: boolean | null;
  userId?: string | null;

}
