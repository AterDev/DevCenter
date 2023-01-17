using Microsoft.Extensions.Hosting;

namespace Http.Application.Services;

/// <summary>
/// 文件服务
/// </summary>
public class FileService
{
    public string LocalPath { get; }

    private readonly IHostEnvironment _env;
    public FileService(
        IHostEnvironment env)
    {
        _env = env;
        LocalPath = Path.Combine(_env.ContentRootPath, "wwwroot", "Uploads");
    }

    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public string SaveFile(string path, Stream stream)
    {
        string filePath = Path.Combine(LocalPath, path);
        if (File.Exists(filePath))
        {
            return filePath;
        }
        // 创建目录
        string? dirPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(dirPath))
        {
            _ = Directory.CreateDirectory(dirPath!);
        }
        using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
        _ = stream.Seek(0, SeekOrigin.Begin);
        stream.CopyTo(fileStream);
        return filePath;
    }
}
