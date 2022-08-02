import { JobType } from '../enum/job-type.model';
/**
 * 通过ssh构建选项
 */
export interface SSHOption {
  /**
   * job名称
   */
  jobName: string;
  /**
   * 0 = Dotnet
1 = Static
   */
  type?: JobType | null;
  /**
   * 分支，默认dev
   */
  branchName?: string | null;
  /**
   * 远程主机连接 user@12.34.56.78
   */
  sshHost: string;
  /**
   * 要构建的项目目录,相对于仓库根目录
   */
  projectPath?: string | null;
  /**
   * 构建生成的目录,CI主机的目录
   */
  publishPath: string;
  /**
   * 远程运行的目录
   */
  runPath: string;
  serviceName: string;

}
