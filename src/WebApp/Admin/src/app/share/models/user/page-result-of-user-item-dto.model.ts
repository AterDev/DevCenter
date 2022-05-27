import { UserItemDto } from '../user/user-item-dto.model';
export interface PageResultOfUserItemDto {
  count: number;
  data?: UserItemDto[] | null;
  pageIndex: number;

}
