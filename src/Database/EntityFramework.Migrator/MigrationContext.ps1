$time = [DateTime]::Now.ToString("yyyyMMdd-HHmmss");
dotnet ef migrations add $time -c ContextBase -o Migrations
