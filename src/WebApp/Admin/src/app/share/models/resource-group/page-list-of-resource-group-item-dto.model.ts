import { ResourceGroupItemDto } from '../resource-group/resource-group-item-dto.model';
export interface PageListOfResourceGroupItemDto {
  count: number;
  data?: ResourceGroupItemDto[];
  pageIndex: number;

}
