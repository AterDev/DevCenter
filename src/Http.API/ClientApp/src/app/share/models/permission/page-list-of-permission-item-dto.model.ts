import { PermissionItemDto } from '../permission/permission-item-dto.model';
export interface PageListOfPermissionItemDto {
  count: number;
  data?: PermissionItemDto[];
  pageIndex: number;

}
