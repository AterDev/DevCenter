import { Status } from '../enum/status.model';
/**
 * 系统用户更新时请求结构
 */
export interface UserUpdateDto {
  /**
   * 用户名
   */
  userName?: string | null;
  /**
   * 真实姓名
   */
  realName?: string | null;
  /**
   * 职位
   */
  position?: string | null;
  email?: string | null;
  emailConfirmed?: boolean | null;
  phoneNumber?: string | null;
  phoneNumberConfirmed?: boolean | null;
  twoFactorEnabled?: boolean | null;
  lockoutEnd?: Date | null;
  lockoutEnabled?: boolean | null;
  accessFailedCount?: number | null;
  /**
   * 最后登录时间
   */
  lastLoginTime?: Date | null;
  /**
   * 密码重试次数
   */
  retryCount?: number | null;
  isDeleted?: boolean | null;
  /**
   * 头像url
   */
  avatar?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
