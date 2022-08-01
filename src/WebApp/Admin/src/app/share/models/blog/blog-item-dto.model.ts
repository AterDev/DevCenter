import { Status } from '../enum/status.model';
/**
 * 文章内容列表元素
 */
export interface BlogItemDto {
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
