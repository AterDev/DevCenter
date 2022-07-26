import { DocumentItemDto } from '../document/document-item-dto.model';
export interface PageListOfDocumentItemDto {
  count: number;
  data?: DocumentItemDto[];
  pageIndex: number;

}
