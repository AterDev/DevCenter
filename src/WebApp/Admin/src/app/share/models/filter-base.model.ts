export interface FilterBase {
  pageIndex: number;
  pageSize: number;
  tenantId?: string | null;
  minCreatedTime?: Date | null;
  maxCreatedTime?: Date | null;

}
