using System.Text;
using Application.Implement;
using Application.Services;
using Application.Services.Webhook;
using Core.Const;
using Http.API;
using Http.API.Jobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Share.Options;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
ConfigurationManager configuration = builder.Configuration;

services.Configure<WebhookOptions>(configuration.GetSection("Webhook"));
services.AddHttpContextAccessor();
// database sql
string? connectionString = configuration.GetConnectionString("Default");
services.AddDbContextPool<QueryDbContext>(option =>
{
    option.UseNpgsql(connectionString, sql =>
    {
        sql.MigrationsAssembly("Http.API");
        sql.CommandTimeout(10);
    });
});
services.AddDbContextPool<CommandDbContext>(option =>
{
    option.UseNpgsql(connectionString, sql =>
    {
        sql.MigrationsAssembly("Http.API");
        sql.CommandTimeout(10);
    });
});

services.Configure<GitLabOption>(configuration.GetSection("GitLab"));

services.AddSingleton(typeof(GitLabWebhookService));
services.AddSingleton(typeof(DingTalkWebhookService));

services.AddHttpContextAccessor();
services.AddDataStore();
services.AddManager();

services.AddHostedService<GitLabTask>();
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

// 验证
services.AddAuthorization(options =>
{
    options.AddPolicy(Const.User, policy =>
        policy.RequireRole("Admin", "User", "Developer", "DevOps"));
    options.AddPolicy(Const.Admin, policy =>
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

#if DEBUG
// api 接口文档设置
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevCenter",
        Description = "API",
        Version = "v1"
    });
    string[] xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
    foreach (string item in xmlFiles)
    {
        try
        {
            c.IncludeXmlComments(item, includeControllerXmlComments: true);
        }
        catch (Exception) { }
    }
    c.DescribeAllParametersInCamelCase();
    c.CustomOperationIds((z) =>
    {
        ControllerActionDescriptor descriptor = (ControllerActionDescriptor)z.ActionDescriptor;
        return $"{descriptor.ControllerName}_{descriptor.ActionName}";
    });

    c.SchemaFilter<EnumSchemaFilter>();
    c.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});
#endif

services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

WebApplication app = builder.Build();

// 初始化工作
await using (AsyncServiceScope scope = app.Services.CreateAsyncScope())
{
    IServiceProvider provider = scope.ServiceProvider;
    await InitDataTask.InitDataAsync(provider);
}

if (app.Environment.IsDevelopment())
{
    app.UseCors("default");
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // 生产环境需要新的配置
    app.UseCors("default");
    //app.UseHsts();
    //app.UseHttpsRedirection();
}
app.UseStaticFiles();
// 异常统一处理
app.UseExceptionHandler(handler =>
{
    handler.Run(async context =>
    {
        context.Response.StatusCode = 500;
        Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        var result = new {
            Title = "程序内部错误:" + exception?.Message,
            Detail = exception?.Source + exception?.StackTrace,
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

using (app)
{
    app.Start();
    // 初始化工作
    await using (AsyncServiceScope scope = app.Services.CreateAsyncScope())
    {
        IServiceProvider provider = scope.ServiceProvider;
        await InitDataTask.InitDataAsync(provider);
    }
    app.WaitForShutdown();
}

public partial class Program { }