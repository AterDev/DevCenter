import { EntityBase } from '../entity-base.model';
import { LibraryType } from '../enum/library-type.model';
import { User } from '../user/user.model';
import { CodeSnippet } from '../code-snippet/code-snippet.model';
export interface CodeLibrary extends EntityBase {
  namespace: string;
  description?: string | null;
  /**
   * 0 = Code
1 = Script
2 = Config
3 = DevOps
   */
  type?: LibraryType | null;
  isValid: boolean;
  isPublic: boolean;
  user?: User | null;
  snippets?: CodeSnippet[] | null;

}
