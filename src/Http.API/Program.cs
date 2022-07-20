using System.Text;
using Http.Application.Implement;
using Http.Application.Services.Webhook;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;

using Share.Options;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<WebhookOptions>(configuration.GetSection("Webhook"));
services.AddHttpContextAccessor();
// database sql
var connectionString = configuration.GetConnectionString("Default");
services.AddDbContextPool<ContextBase>(option =>
{
    option.UseNpgsql(connectionString, sql => { sql.MigrationsAssembly("EntityFramework.Migrator"); });
});
services.AddDbContextPool<QueryDbContext>(option =>
{
    option.UseNpgsql(connectionString, sql => { sql.MigrationsAssembly("EntityFramework.Migrator"); });
});
services.AddDbContextPool<CommandDbContext>(option =>
{
    option.UseNpgsql(connectionString, sql => { sql.MigrationsAssembly("EntityFramework.Migrator"); });
});


// redis
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = builder.Configuration.GetConnectionString("Redis");
//    options.InstanceName = builder.Configuration.GetConnectionString("RedisInstanceName");
//});
//services.AddSingleton(typeof(RedisService));
services.AddSingleton(typeof(GitLabWebhookService));
services.AddSingleton(typeof(DingTalkWebhookService));
services.AddDataStore();

//services.AddScoped(typeof(FileService));

#region 接口相关内容:jwt/授权/cors
// use jwt
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(cfg =>
{
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt")["Sign"])),
        ValidIssuer = configuration.GetSection("Jwt")["Issuer"],
        ValidAudience = configuration.GetSection("Jwt")["Audience"],
        ValidateIssuer = true,
        ValidateLifetime = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true
    };
});

// use OpenIddict
//services.AddAuthentication(options =>
//{
//    options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
//});
//services.AddOpenIddict()
//    .AddValidation(options =>
//    {
//        options.SetIssuer("https://localhost:5001/");
//        options.UseIntrospection()
//            .SetClientId("api")
//            .SetClientSecret("myApiTestSecret");

//        options.UseSystemNetHttp();
//        options.UseAspNetCore();
//    });

// 验证
services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
        policy.RequireRole("Admin", "User", "Developer", "DevOps"));
    options.AddPolicy("Admin", policy =>
        policy.RequireRole("Admin"));
});

// cors配置 
services.AddCors(options =>
{
    options.AddPolicy("default", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
#endregion

services.AddHealthChecks();
// api 接口文档设置
services.AddOpenApiDocument(c =>
{
    c.GenerateXmlObjects = true;
    c.GenerateEnumMappingDescription = true;
    c.UseControllerSummaryAsTagDescription = true;
    c.PostProcess = (document) =>
    {
        document.Info.Title = "DevCenter";
        document.Info.Description = "Api 文档";
        document.Info.Version = "1.0";
    };
});
services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// 初始化工作
await using (var scope = app.Services.CreateAsyncScope())
{
    var provider = scope.ServiceProvider;
    await InitDataTask.InitDataAsync(provider);
}


if (app.Environment.IsDevelopment())
{
    app.UseCors("default");
    app.UseDeveloperExceptionPage();
    app.UseOpenApi();
    app.UseSwaggerUi3(c => { c.DocumentTitle = "文档"; });
    app.UseStaticFiles();
}
else
{
    // 生产环境需要新的配置
    app.UseCors("default");
    app.UseStaticFiles();
    //app.UseHsts();
    //app.UseHttpsRedirection();
}
// 异常统一处理
app.UseExceptionHandler(handler =>
{
    handler.Run(async context =>
    {
        context.Response.StatusCode = 500;
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        var result = new
        {
            Title = "程序内部错误:" + exception?.Message,
            Detail = exception?.Source,
            Status = 500,
            TraceId = context.TraceIdentifier
        };
        await context.Response.WriteAsJsonAsync(result);
    });
});

app.UseHealthChecks("/health");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

public partial class Program { }