namespace Core.Entities;
public class Enums
{
}

/// <summary>
/// 性别
/// </summary>
public enum SexType
{
    Male,
    Female,
    Else
}

public enum NavigationType
{
    Default = 0,
    /// <summary>
    /// 站点
    /// </summary>
    WebSite,
    /// <summary>
    /// 工具
    /// </summary>
    Tools,
    /// <summary>
    /// 服务器
    /// </summary>
    Server,
    /// <summary>
    /// 代码片段
    /// </summary>
    CodeSnippets
}
public enum LayoutType
{
    Default,
    Card,
    Grid,
    List,
    Table
}

public enum ValueType
{
    Default,
    String,
    Long,
    Boolean,
    Double,
    Datetime,
    Json
}
public enum SecretType
{
    /// <summary>
    /// 用户密码
    /// </summary>
    Password,
    /// <summary>
    /// 私有token
    /// </summary>
    PAT,
    /// <summary>
    /// key/secret
    /// </summary>
    Secret,
    /// <summary>
    /// 证书
    /// </summary>
    RSA
}