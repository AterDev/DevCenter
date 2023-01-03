import { UserItemDto } from '../user/user-item-dto.model';
export interface PageListOfUserItemDto {
  count: number;
  data?: UserItemDto[];
  pageIndex: number;

}
