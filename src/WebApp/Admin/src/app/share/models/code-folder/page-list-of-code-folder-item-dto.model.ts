import { CodeFolderItemDto } from '../code-folder/code-folder-item-dto.model';
export interface PageListOfCodeFolderItemDto {
  count: number;
  data?: CodeFolderItemDto[];
  pageIndex: number;

}
