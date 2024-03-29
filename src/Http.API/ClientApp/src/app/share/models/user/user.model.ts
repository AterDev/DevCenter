import { EntityBase } from '../entity-base.model';
import { Role } from '../role/role.model';
import { Blog } from '../blog/blog.model';
import { Comment } from '../comment/comment.model';
import { CodeSnippet } from '../code-snippet/code-snippet.model';
export interface User extends EntityBase {
  userName: string;
  realName?: string | null;
  position?: string | null;
  email: string;
  emailConfirmed: boolean;
  passwordHash: string;
  passwordSalt: string;
  phoneNumber?: string | null;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd?: Date | null;
  lockoutEnabled: boolean;
  accessFailedCount: number;
  lastLoginTime?: Date | null;
  retryCount: number;
  avatar?: string | null;
  roles?: Role[] | null;
  blogs?: Blog[] | null;
  comments?: Comment[] | null;
  codeSnippets?: CodeSnippet[] | null;

}
