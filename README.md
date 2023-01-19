# DevCenter
一个针对开发团队内部使用的资源导航系统
# 安装
## 源码
项目基于`ASP.NET Core 6 + Angular14`，你可以拉取源代码，然后根据自己的需求自由部署。

项目数据库默认使用`PostgreSQL`，基于`EF Core`，你可以根据自己的需求自由修改。

在`Http.Application`项目中的`Config`类，定义了初始数据，你可以在部署前进行自定义。

## Docker
您可以自己配置好数据库，然后启动容器时将`连接字符串`作为`环境变量`传入。

```pwsh
# 拉取镜像
docker pull niltor/dev-center:latest
# 运行，指定数据库连接字符串(不要使用localhost)
docker run -p 9161:80 -d --name DevCenter -e ConnectionStrings__Default="Server=192.168.0.1;Port=5432;Database=DevCenter;User Id=postgres;Password=root;" niltor/dev-center 
```

## Docker Compose
如果你还没有准备和配置好数据库，可以使用`docker-compose`直接启动相关服务。

```pwsh
docker-compose -p dev up -d
```

`docker-compose.yaml`
```yaml
version: "1"
networks:
  devCenter:
services:
  dev-center:
    image: niltor/dev-center:latest
    ports:
      - "9161:80"
    environment:
      ConnectionStrings__Default: "Server=db;Port=5432;Database=DevCenter;User Id=postgres;password=root;"
    depends_on:
      db:
        condition: service_healthy
    networks:
      - devCenter

  db:
    image: postgres:15.1-alpine
    command:
      - -i
      # ports:
      # - "5432:5432"
    environment:
      POSTGRES_PASSWORD: "root"

    healthcheck:
      test: [ "CMD", "pg_isready" ]
      interval: 3s
      timeout: 2s
      retries: 5
    networks:
      - devCenter

```

# 使用
默认管理用户为`admin/123456`。
## 定义环境
- 如开发、测试、生产环境
## 定义资源类型
- 如网站、服务器、数据库等

## 定义资源标签
- 标签用来标识资源，一个资源可以有多个标签
标签的图标，参考[谷歌fonts](https://fonts.google.com/icons).
## 定义资源属性
- 一个属性对应一个字段值，多个资源属性组合为一个资源类型。如网站类型的资源 ，通常包括`url`,`名称`等资源属性

## 添加资源组
- 一组具有相似特征的资源，通常会分配到一个资源组
- 角色权限分配的最小单位为资源组
## 添加资源
- 选择资源组
- 选择资源类型
- 填写资源属性值
- 选择标签
