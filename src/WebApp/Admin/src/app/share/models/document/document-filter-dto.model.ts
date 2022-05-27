import { FilterBase } from '../filter-base.model';
export interface DocumentFilterDto extends FilterBase {
  /**
   * 文件名
   */
  fileName?: string | null;
  /**
   * 文件类型
   */
  ext?: string | null;
  /**
   * 文件路径
   */
  filePath?: string | null;
  folderId?: string | null;

}
