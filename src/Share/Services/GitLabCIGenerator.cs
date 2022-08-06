namespace Share.Services;
public class GitLabCIGenerator
{
    #region 模型类定义
    /// <summary>
    /// 通过ssh构建选项
    /// </summary>
    public class SSHOption
    {
        /// <summary>
        /// job名称
        /// </summary>
        public string JobName { get; set; } = default!;
        public JobType Type { get; set; } = JobType.Static;
        /// <summary>
        /// 分支，默认dev
        /// </summary>
        public string? BranchName { get; set; } = "dev";
        /// <summary>
        /// 远程主机连接 user@12.34.56.78
        /// </summary>
        public string SSHHost { get; set; } = default!;
        /// <summary>
        /// 要构建的项目目录,相对于仓库根目录
        /// </summary>
        public string? ProjectPath { get; set; } = "./";
        /// <summary>
        /// 构建生成的目录,CI主机的目录
        /// </summary>
        public string PublishPath { get; set; }
        /// <summary>
        /// 远程运行的目录
        /// </summary>
        public string RunPath { get; set; } = default!;
        public string ServiceName { get; set; }
    }

    /// <summary>
    /// 通过docker 构建选项
    /// </summary>
    public class DockerOption
    {
        public string JobName { get; set; } = default!;
        /// <summary>
        /// 容器名称
        /// </summary>
        public string ContainerName { get; set; } = default!;
    }
    public enum JobType
    {
        /// <summary>
        /// dotnet
        /// </summary>
        Dotnet,
        /// <summary>
        /// 静态文件
        /// </summary>
        Static
    }
    #endregion
    #region 模板

    private static string JobTmp = @"stages:    
  - publish
${JobName}: 
  variables:
    SSH_HOST: '${SSH_HOST}'
    PROJECT_PATH: '${ProjectPath}'
    PUBLISH_PATH: '${PublishPath}'
    RUN_PATH: '${RunPath}'
  stage: publish";

    private static string Rules = @"
  rules: 
    - if: '$CI_PIPELINE_SOURCE == ""push"" && $CI_COMMIT_BRANCH == ""${BranchName}""'
      changes:
        - ${ProjectPath}/**/*
      when: always";

    /// <summary>
    /// 文件复制脚本
    /// </summary>
    private static string CopyTmp = @"
    - mkdir -p $PUBLISH_PATH
    - cd $PUBLISH_PATH
    - ssh $SSH_HOST sudo mkdir -p $RUN_PATH
    - scp -r./* $SSH_HOST:$RUN_PATH
";

    /// <summary>
    /// dotnet 构建及复制脚本
    /// </summary>
    private static string DotNetTmp = @"
    - mkdir -p $PUBLISH_PATH
    - dotnet build $PROJECT_PATH
    - dotnet publish $PROJECT_PATH -c Release -o $PUBLISH_PATH
    - cd $PUBLISH_PATH
    - ssh $SSH_HOST sudo mkdir -p $RUN_PATH
    - scp -r ./* $SSH_HOST:$RUN_PATH
    - ssh $SSH_HOST sudo systemctl restart ${ServiceName}
";

    #endregion
    public GitLabCIGenerator()
    {

    }

    /// <summary>
    /// 构建脚本
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    public static string GetYmlContent(SSHOption option)
    {
        var content = JobTmp.Replace("${JobName}", option.JobName)
            .Replace("${SSH_HOST}", option.SSHHost)
            .Replace("${ProjectPath}", option.ProjectPath)
            .Replace("${PublishPath}", option.PublishPath)
            .Replace("${RunPath}", option.RunPath);

        var rules = Rules.Replace("${ProjectPath}", option.ProjectPath)
            .Replace("${BranchName}", option.BranchName);
        var scripts = "  script:";
        switch (option.Type)
        {
            case JobType.Dotnet:
                scripts += DotNetTmp.Replace("${ServiceName}", option.ServiceName);
                break;
            case JobType.Static:
                scripts += CopyTmp;
                break;
            default:
                break;
        }
        return content + rules + Environment.NewLine + scripts;
    }

}
