$Env:ASPNETCORE_ENVIRONMENT="Production"
dotnet ef database update  -c ContextBase
$Env:ASPNETCORE_ENVIRONMENT=""