import { EntityBase } from '../entity-base.model';
import { Document } from '../document/document.model';
export interface DocFolder extends EntityBase {
  name: string;
  parent?: DocFolder | null;
  children?: DocFolder[] | null;
  documents?: Document[] | null;

}
