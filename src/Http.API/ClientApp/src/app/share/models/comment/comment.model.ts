import { EntityBase } from '../entity-base.model';
import { Blog } from '../blog/blog.model';
import { User } from '../user/user.model';
export interface Comment extends EntityBase {
  blog?: Blog | null;
  user?: User | null;
  content?: string | null;

}
