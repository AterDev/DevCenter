import { EnvironmentItemDto } from '../environment/environment-item-dto.model';
export interface PageResultOfEnvironmentItemDto {
  count: number;
  data?: EnvironmentItemDto[] | null;
  pageIndex: number;

}
