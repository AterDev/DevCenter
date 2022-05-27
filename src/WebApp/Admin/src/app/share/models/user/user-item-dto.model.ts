import { Status } from '../enum/status.model';
/**
 * 系统用户列表元素
 */
export interface UserItemDto {
  /**
   * 用户名
   */
  userName: string;
  /**
   * 真实姓名
   */
  realName?: string | null;
  /**
   * 职位
   */
  position?: string | null;
  email?: string | null;
  emailConfirmed: boolean;
  phoneNumber?: string | null;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd?: Date | null;
  lockoutEnabled: boolean;
  accessFailedCount: number;
  /**
   * 最后登录时间
   */
  lastLoginTime?: Date | null;
  /**
   * 密码重试次数
   */
  retryCount: number;
  isDeleted: boolean;
  /**
   * 头像url
   */
  avatar?: string | null;
  id: string;
  /**
   * 状态
   */
  status?: Status;
  createdTime: Date;
  updatedTime: Date;

}
