/**
 * 系统用户添加时请求结构
 */
export interface UserAddDto {
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
  password?: string | null;
  phoneNumber?: string | null;
  /**
   * 头像url
   */
  avatar?: string | null;

}
