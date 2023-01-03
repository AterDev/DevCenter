import { ResourceItemDto } from '../old-resource/resource-item-dto.model';
export interface PageListOfResourceItemDto {
  count: number;
  data?: ResourceItemDto[];
  pageIndex: number;

}
