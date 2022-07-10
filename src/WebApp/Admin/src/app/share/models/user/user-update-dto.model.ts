import { Status } from '../enum/status.model';
/**
 * 系统用户更新时请求结构
 */
export interface UserUpdateDto {
  /**
   * 真实姓名
   */
  realName?: string | null;
  /**
   * 职位
   */
  position?: string | null;
  email?: string | null;
  password?: string | null;
  phoneNumber?: string | null;
  /**
   * 角色id
   */
  roleIds?: string[] | null;
  /**
   * 头像url
   */
  avatar?: string | null;
  /**
   * 状态
   */
  status?: Status | null;

}
