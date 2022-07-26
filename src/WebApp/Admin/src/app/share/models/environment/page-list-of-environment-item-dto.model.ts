import { EnvironmentItemDto } from '../environment/environment-item-dto.model';
export interface PageListOfEnvironmentItemDto {
  count: number;
  data?: EnvironmentItemDto[];
  pageIndex: number;

}
