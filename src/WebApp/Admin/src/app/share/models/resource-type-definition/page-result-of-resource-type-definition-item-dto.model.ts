import { ResourceTypeDefinitionItemDto } from '../resource-type-definition/resource-type-definition-item-dto.model';
export interface PageResultOfResourceTypeDefinitionItemDto {
  count: number;
  data?: ResourceTypeDefinitionItemDto[] | null;
  pageIndex: number;

}
