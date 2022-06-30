/**
 * 资源组
 */
export interface ResourceGroupAddDto {
  name: string;
  /**
   * 描述
   */
  descriptioin?: string | null;
  environmentId: string;

}
