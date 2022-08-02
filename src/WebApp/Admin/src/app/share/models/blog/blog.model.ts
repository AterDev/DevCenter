import { EntityBase } from '../entity-base.model';
import { User } from '../user/user.model';
import { BlogCatalog } from '../blog-catalog/blog-catalog.model';
import { Comment } from '../comment/comment.model';
import { BlogTag } from '../blog-tag/blog-tag.model';
export interface Blog extends EntityBase {
  title: string;
  summary?: string | null;
  authorName?: string | null;
  user?: User | null;
  isPrivate?: boolean | null;
  content?: string | null;
  catalog?: BlogCatalog | null;
  comments?: Comment[] | null;
  blogTags?: BlogTag[] | null;

}
