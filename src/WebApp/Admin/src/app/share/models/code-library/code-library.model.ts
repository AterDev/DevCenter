import { EntityBase } from '../entity-base.model';
import { User } from '../user/user.model';
import { CodeSnippet } from '../code-snippet/code-snippet.model';
export interface CodeLibrary extends EntityBase {
  namespace: string;
  description?: string | null;
  language?: string | null;
  isValid: boolean;
  isPublic: boolean;
  user?: User | null;
  snippets?: CodeSnippet[] | null;

}
