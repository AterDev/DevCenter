import { ResourceItemDto } from '../resource/resource-item-dto.model';
export interface PageListOfResourceItemDto {
  count: number;
  data?: ResourceItemDto[];
  pageIndex: number;

}
