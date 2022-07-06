import { FilterBase } from '../filter-base.model';
export interface UserFilterDto extends FilterBase {
  /**
   * 用户名
   */
  userName?: string | null;
  email?: string | null;
  emailConfirmed?: boolean | null;
  phoneNumberConfirmed?: boolean | null;
  twoFactorEnabled?: boolean | null;
  lockoutEnabled?: boolean | null;
  accessFailedCount?: number | null;
  /**
   * 密码重试次数
   */
  retryCount?: number | null;

}
