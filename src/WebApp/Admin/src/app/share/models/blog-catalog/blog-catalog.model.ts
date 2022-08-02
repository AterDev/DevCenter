import { EntityBase } from '../entity-base.model';
import { Blog } from '../blog/blog.model';
export interface BlogCatalog extends EntityBase {
  name: string;
  type?: string | null;
  sort: number;
  level: number;
  articles?: Blog[] | null;
  parent?: BlogCatalog | null;
  parentId?: string | null;
  catalogs?: BlogCatalog[] | null;

}
