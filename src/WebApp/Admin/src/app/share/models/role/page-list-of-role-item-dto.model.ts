import { RoleItemDto } from '../role/role-item-dto.model';
export interface PageListOfRoleItemDto {
  count: number;
  data?: RoleItemDto[];
  pageIndex: number;

}
