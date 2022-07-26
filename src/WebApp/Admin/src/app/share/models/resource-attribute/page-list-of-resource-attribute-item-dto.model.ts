import { ResourceAttributeItemDto } from '../resource-attribute/resource-attribute-item-dto.model';
export interface PageListOfResourceAttributeItemDto {
  count: number;
  data?: ResourceAttributeItemDto[];
  pageIndex: number;

}
