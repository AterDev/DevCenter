namespace Core.Models;
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
    Inner
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