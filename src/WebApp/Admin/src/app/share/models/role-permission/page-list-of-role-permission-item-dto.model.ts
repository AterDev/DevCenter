import { RolePermissionItemDto } from '../role-permission/role-permission-item-dto.model';
export interface PageListOfRolePermissionItemDto {
  count: number;
  data?: RolePermissionItemDto[];
  pageIndex: number;

}
