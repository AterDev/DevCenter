import { ResourceAttributeItemDto } from '../resource-attribute/resource-attribute-item-dto.model';
export interface PageResultOfResourceAttributeItemDto {
  count: number;
  data?: ResourceAttributeItemDto[] | null;
  pageIndex: number;

}
