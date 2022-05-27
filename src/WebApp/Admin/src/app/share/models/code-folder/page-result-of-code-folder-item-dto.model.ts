import { CodeFolderItemDto } from '../code-folder/code-folder-item-dto.model';
export interface PageResultOfCodeFolderItemDto {
  count: number;
  data?: CodeFolderItemDto[] | null;
  pageIndex: number;

}
