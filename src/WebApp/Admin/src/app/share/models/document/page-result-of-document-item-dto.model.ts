import { DocumentItemDto } from '../document/document-item-dto.model';
export interface PageResultOfDocumentItemDto {
  count: number;
  data?: DocumentItemDto[] | null;
  pageIndex: number;

}
