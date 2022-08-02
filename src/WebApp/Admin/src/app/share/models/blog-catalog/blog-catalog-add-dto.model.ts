export interface BlogCatalogAddDto {
  name: string;
  type?: string | null;
  sort: number;
  level: number;
  parentId?: string | null;

}
