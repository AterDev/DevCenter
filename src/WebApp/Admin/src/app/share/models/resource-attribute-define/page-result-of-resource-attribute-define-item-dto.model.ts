import { ResourceAttributeDefineItemDto } from '../resource-attribute-define/resource-attribute-define-item-dto.model';
export interface PageResultOfResourceAttributeDefineItemDto {
  count: number;
  data?: ResourceAttributeDefineItemDto[] | null;
  pageIndex: number;

}
