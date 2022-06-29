dotnet publish ..\src\Http.API\Http.API.csproj  -c release -r ubuntu.20.04-x64 --no-self-contained -o ..\publish
scp  -r ../publish/*  dev:/var/webapi/dev-center/
ssh dev 'echo genars807@YJ |  sudo -S systemctl restart dev-center.service'