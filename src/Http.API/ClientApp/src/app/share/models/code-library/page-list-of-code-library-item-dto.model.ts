import { CodeLibraryItemDto } from '../code-library/code-library-item-dto.model';
export interface PageListOfCodeLibraryItemDto {
  count: number;
  data?: CodeLibraryItemDto[];
  pageIndex: number;

}
