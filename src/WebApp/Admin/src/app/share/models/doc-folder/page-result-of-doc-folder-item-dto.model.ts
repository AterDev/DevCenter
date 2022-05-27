import { DocFolderItemDto } from '../doc-folder/doc-folder-item-dto.model';
export interface PageResultOfDocFolderItemDto {
  count: number;
  data?: DocFolderItemDto[] | null;
  pageIndex: number;

}
