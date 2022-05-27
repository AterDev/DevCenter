import { RolePermissionItemDto } from '../role-permission/role-permission-item-dto.model';
export interface PageResultOfRolePermissionItemDto {
  count: number;
  data?: RolePermissionItemDto[] | null;
  pageIndex: number;

}
