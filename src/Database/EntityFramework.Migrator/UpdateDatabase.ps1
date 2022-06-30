$Env:ASPNETCORE_ENVIRONMENT="Development"
dotnet ef database update  -c ContextBase

$Env:ASPNETCORE_ENVIRONMENT=""