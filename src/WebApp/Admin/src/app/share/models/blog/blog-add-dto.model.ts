/**
 * 文章内容添加时请求结构
 */
export interface BlogAddDto {
  /**
   * 标题
   */
  title: string;
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
  userId: string;
  catalogId: string;

}
