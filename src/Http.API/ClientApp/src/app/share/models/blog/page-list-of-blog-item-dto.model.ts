import { BlogItemDto } from '../blog/blog-item-dto.model';
export interface PageListOfBlogItemDto {
  count: number;
  data?: BlogItemDto[];
  pageIndex: number;

}
