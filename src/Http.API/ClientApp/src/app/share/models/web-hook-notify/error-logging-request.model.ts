export interface ErrorLoggingRequest {
  environment: string;
  traceId: string;
  /**
   * 详细信息
   */
  errorDetail: string;
  title: string;
  /**
   * 项目名
   */
  projectName: string;
  /**
   * 服务名
   */
  serviceName: string;
  /**
   * 筛选标识名
   */
  filterName: string;
  /**
   * 路由
   */
  route?: string | null;
  /**
   * 请求内容
   */
  requestBody?: string | null;
  /**
   * query string
   */
  queryString?: string | null;

}
