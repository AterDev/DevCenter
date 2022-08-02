import { BlogCatalogItemDto } from '../blog-catalog/blog-catalog-item-dto.model';
export interface PageListOfBlogCatalogItemDto {
  count: number;
  data?: BlogCatalogItemDto[];
  pageIndex: number;

}
