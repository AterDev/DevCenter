import { EntityBase } from '../entity-base.model';
import { Blog } from '../blog/blog.model';
export interface BlogTag extends EntityBase {
  name: string;
  color?: string | null;
  icon?: string | null;
  blogs?: Blog[] | null;

}
