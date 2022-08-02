import { Language } from '../enum/language.model';
import { CodeType } from '../enum/code-type.model';
/**
 * 代码片段列表元素
 */
export interface CodeSnippetItemDto {
  /**
   * 名称
   */
  name: string;
  /**
   * 描述
   */
  description?: string | null;
  /**
   * 语言类型
   */
  language?: Language;
  /**
   * 类型
   */
  codeType?: CodeType;
  id: string;
  createdTime: Date;
  updatedTime: Date;

}
