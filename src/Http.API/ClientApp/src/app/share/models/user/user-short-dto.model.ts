/**
 * 系统用户概要
 */
export interface UserShortDto {
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
  email: string;
  emailConfirmed: boolean;
  phoneNumber?: string | null;
  phoneNumberConfirmed: boolean;
  /**
   * 最后登录时间
   */
  lastLoginTime?: Date | null;
  /**
   * 头像url
   */
  avatar?: string | null;
  id: string;

}
