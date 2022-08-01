import { Status } from '../enum/status.model';
/**
 * 模型库更新时请求结构
 */
export interface CodeLibraryUpdateDto {
  /**
   * 库命名空间
   */
  namespace?: string | null;
  /**
   * 描述
   */
  description?: string | null;
  /**
   * 语言类型
   */
  language?: string | null;
  /**
   * 是否有效
   */
  isValid?: boolean | null;
  /**
   * 是否公开
   */
  isPublic?: boolean | null;
  status?: Status | null;
  isDeleted?: boolean | null;
  userId?: string | null;

}
