import { FilterBase } from '../filter-base.model';
import { Language } from '../enum/language.model';
import { CodeType } from '../enum/code-type.model';
export interface CodeSnippetFilterDto extends FilterBase {
  /**
   * 名称
   */
  name?: string | null;
  /**
   * 语言类型
   */
  language?: Language | null;
  /**
   * 类型
   */
  codeType?: CodeType | null;
  userId?: string | null;
  libraryId?: string | null;

}
