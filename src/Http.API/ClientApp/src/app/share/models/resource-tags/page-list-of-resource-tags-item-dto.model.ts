import { ResourceTagsItemDto } from '../resource-tags/resource-tags-item-dto.model';
export interface PageListOfResourceTagsItemDto {
  count: number;
  data?: ResourceTagsItemDto[];
  pageIndex: number;

}
