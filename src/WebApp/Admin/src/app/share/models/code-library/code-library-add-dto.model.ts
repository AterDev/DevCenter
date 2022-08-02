import { LibraryType } from '../enum/library-type.model';
/**
 * 模型库添加时请求结构
 */
export interface CodeLibraryAddDto {
  /**
   * 库命名空间
   */
  namespace: string;
  /**
   * 描述
   */
  description?: string | null;
  /**
   * 语言类型
   */
  type?: LibraryType;
  /**
   * 是否有效
   */
  isValid: boolean;
  /**
   * 是否公开
   */
  isPublic: boolean;
  userId: string;

}
