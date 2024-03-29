﻿using Application.IManager;
using Application.Services;
using Share.Models.AuthDtos;

namespace Http.API.Controllers;

/// <summary>
/// 系统用户授权登录
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserManager userManager;
    private readonly IConfiguration _config;
    //private readonly RedisService _redis;
    public AuthController(IUserManager userManager,
                          IConfiguration config
        //RedisService redis
        )
    {
        this.userManager = userManager;
        _config = config;
        //_redis = redis;
    }

    /// <summary>
    /// 登录获取Token
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<AuthResult>> LoginAsync(LoginDto dto)
    {
        User? user = await userManager.Query.Db.Where(u => u.UserName.Equals(dto.UserName)
            || u.Email.Equals(dto.UserName))
            .Where(u => u.IsDeleted == false)
            .Include(u => u.Roles)
            .FirstOrDefaultAsync();
        if (user == null)
        {
            return NotFound("不存在该用户");
        }

        if (HashCrypto.Validate(dto.Password, user.PasswordSalt, user.PasswordHash))
        {
            string? sign = _config.GetSection("Jwt")["Sign"];
            string? issuer = _config.GetSection("Jwt")["Issuer"];
            string? audience = _config.GetSection("Jwt")["Audience"];

            Role? role = user.Roles?.FirstOrDefault();
            long time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (!string.IsNullOrWhiteSpace(sign) &&
            !string.IsNullOrWhiteSpace(issuer) &&
            !string.IsNullOrWhiteSpace(audience))
            {
                JwtService jwt = new(sign, audience, issuer)
                {
                    TokenExpires = 60 * 24 * 7,
                };
                string token = jwt.GetToken(user.Id.ToString(), role?.IdentifyName ?? "");

                return new AuthResult
                {
                    Id = user.Id,
                    Role = role?.IdentifyName ?? "",
                    Token = token,
                    Username = user.UserName
                };
            }
            else
            {
                throw new Exception("缺少Jwt配置内容");
            }
        }
        else
        {
            return Problem("用户名或密码错误", title: "");
        }
    }

    /// <summary>
    /// 退出 
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<bool>> LogoutAsync([FromRoute] Guid id)
    {
        //var user = await _store.FindAsync(id);
        //if (user == null) return NotFound();
        // 清除redis登录状态
        //await _redis.Cache.RemoveAsync(id.ToString());
        return await Task.FromResult(true);
    }


}
