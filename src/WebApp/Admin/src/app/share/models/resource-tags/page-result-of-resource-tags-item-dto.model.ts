import { ResourceTagsItemDto } from '../resource-tags/resource-tags-item-dto.model';
export interface PageResultOfResourceTagsItemDto {
  count: number;
  data?: ResourceTagsItemDto[] | null;
  pageIndex: number;

}
