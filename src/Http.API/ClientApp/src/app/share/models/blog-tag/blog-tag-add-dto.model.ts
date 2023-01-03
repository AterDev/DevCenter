/**
 * 博客标签添加时请求结构
 */
export interface BlogTagAddDto {
  name: string;
  color?: string | null;
  icon?: string | null;

}
