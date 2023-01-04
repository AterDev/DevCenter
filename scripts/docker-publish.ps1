$PSDefaultParameterValues['*:Encoding'] = 'utf8'
$location = Get-Location
Set-Location ../

Remove-Item ./publish -Recurse -Force 
dotnet publish .\src\Http.API\Http.API.csproj -o ./publish -c Release
docker build  -f  .\src\Http.API\Dockerfile -t dev-center . 
# docker push dev-center

Set-Location $location