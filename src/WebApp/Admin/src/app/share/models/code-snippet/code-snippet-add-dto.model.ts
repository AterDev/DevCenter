import { Language } from '../enum/language.model';
import { CodeType } from '../enum/code-type.model';
/**
 * 代码片段添加时请求结构
 */
export interface CodeSnippetAddDto {
  /**
   * 名称
   */
  name: string;
  /**
   * 描述
   */
  description?: string | null;
  /**
   * 内容
   */
  content?: string | null;
  /**
   * 语言类型
   */
  language?: Language;
  /**
   * 类型
   */
  codeType?: CodeType;
  libraryId: string;

}
