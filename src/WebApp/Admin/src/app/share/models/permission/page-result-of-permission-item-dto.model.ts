import { PermissionItemDto } from '../permission/permission-item-dto.model';
export interface PageResultOfPermissionItemDto {
  count: number;
  data?: PermissionItemDto[] | null;
  pageIndex: number;

}
