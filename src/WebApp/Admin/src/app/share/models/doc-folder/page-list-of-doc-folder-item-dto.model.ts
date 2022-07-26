import { DocFolderItemDto } from '../doc-folder/doc-folder-item-dto.model';
export interface PageListOfDocFolderItemDto {
  count: number;
  data?: DocFolderItemDto[];
  pageIndex: number;

}
