import { RoleItemDto } from '../role/role-item-dto.model';
export interface PageResultOfRoleItemDto {
  count: number;
  data?: RoleItemDto[] | null;
  pageIndex: number;

}
