import { Environment } from '../environment/environment.model';
/**
 * 角色对应的资源组
 */
export interface ResourceGroupRoleDto {
  id: string;
  name: string;
  /**
   * 描述
   */
  descriptioin?: string | null;
  environment?: Environment | null;

}
