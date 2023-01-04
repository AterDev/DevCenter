$PSDefaultParameterValues['*:Encoding'] = 'utf8'
$location = Get-Location
Set-Location ../

Remove-Item ./publish -Recurse -Force 
dotnet publish .\src\Http.API\Http.API.csproj -o ./publish -c Release
docker build  -f  .\src\Http.API\Dockerfile -t niltor/dev-center . 
# docker push dev-center

# docker run  -e ConnectionStrings__Default="Server=192.168.3.32;Port=15432;Database=DevCenter;User Id=postgres;Password=root;" dev-center

Set-Location $location