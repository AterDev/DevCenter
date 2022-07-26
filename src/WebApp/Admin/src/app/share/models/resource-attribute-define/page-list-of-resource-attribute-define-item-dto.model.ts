import { ResourceAttributeDefineItemDto } from '../resource-attribute-define/resource-attribute-define-item-dto.model';
export interface PageListOfResourceAttributeDefineItemDto {
  count: number;
  data?: ResourceAttributeDefineItemDto[];
  pageIndex: number;

}
