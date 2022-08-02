import { LibraryType } from '../enum/library-type.model';
import { Status } from '../enum/status.model';
/**
 * 模型库列表元素
 */
export interface CodeLibraryItemDto {
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
