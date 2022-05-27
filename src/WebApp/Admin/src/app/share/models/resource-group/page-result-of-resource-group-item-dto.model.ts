import { ResourceGroupItemDto } from '../resource-group/resource-group-item-dto.model';
export interface PageResultOfResourceGroupItemDto {
  count: number;
  data?: ResourceGroupItemDto[] | null;
  pageIndex: number;

}
