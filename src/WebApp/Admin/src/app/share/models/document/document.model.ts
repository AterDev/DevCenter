import { EntityBase } from '../entity-base.model';
import { DocFolder } from '../doc-folder/doc-folder.model';
export interface Document extends EntityBase {
  fileName: string;
  ext: string;
  filePath: string;
  folder?: DocFolder | null;

}
