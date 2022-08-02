import { Status } from '../enum/status.model';
export interface BlogCatalogUpdateDto {
  name?: string | null;
  type?: string | null;
  sort?: number | null;
  level?: number | null;
  parentId?: string | null;
  status?: Status | null;
  isDeleted?: boolean | null;

}
