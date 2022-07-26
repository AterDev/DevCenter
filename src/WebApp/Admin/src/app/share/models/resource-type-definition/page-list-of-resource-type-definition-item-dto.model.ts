import { ResourceTypeDefinitionItemDto } from '../resource-type-definition/resource-type-definition-item-dto.model';
export interface PageListOfResourceTypeDefinitionItemDto {
  count: number;
  data?: ResourceTypeDefinitionItemDto[];
  pageIndex: number;

}
