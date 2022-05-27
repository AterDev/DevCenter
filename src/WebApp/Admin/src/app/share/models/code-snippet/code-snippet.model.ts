import { EntityBase } from '../entity-base.model';
export interface CodeSnippet extends EntityBase {
  name: string;
  description?: string | null;
  format: string;
  content?: string | null;

}
