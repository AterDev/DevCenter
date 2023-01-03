import { EntityBase } from '../entity-base.model';
import { CodeSnippet } from '../code-snippet/code-snippet.model';
export interface CodeFolder extends EntityBase {
  name: string;
  parent?: CodeFolder | null;
  children?: CodeFolder[] | null;
  documents?: CodeSnippet[] | null;

}
