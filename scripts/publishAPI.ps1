dotnet publish ..\src\Http.API\Http.API.csproj  -c release -o ..\publish
scp  -r ../publish/*  dev:/var/webapi/dev-center/
ssh dev sudo systemctl restart dev-center.service