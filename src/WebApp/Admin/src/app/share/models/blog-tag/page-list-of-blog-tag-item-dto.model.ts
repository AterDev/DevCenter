import { BlogTagItemDto } from '../blog-tag/blog-tag-item-dto.model';
export interface PageListOfBlogTagItemDto {
  count: number;
  data?: BlogTagItemDto[];
  pageIndex: number;

}
