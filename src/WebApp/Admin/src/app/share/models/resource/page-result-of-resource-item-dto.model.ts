import { ResourceItemDto } from '../resource/resource-item-dto.model';
export interface PageResultOfResourceItemDto {
  count: number;
  data?: ResourceItemDto[] | null;
  pageIndex: number;

}
