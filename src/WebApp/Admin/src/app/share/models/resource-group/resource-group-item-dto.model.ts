import { Resource } from '../resource/resource.model';
/**
 * 资源组
 */
export interface ResourceGroupItemDto {
  name: string;
  /**
   * 描述
   */
  descriptioin?: string | null;
  id: string;
  resource?: Resource[] | null;

}
