$PSDefaultParameterValues['*:Encoding'] = 'utf8'
$location = Get-Location
Set-Location ../

if ([System.IO.Directory]::Exists("./publish")) {
    Remove-Item ./publish -Recurse -Force 
}

dotnet publish .\src\Http.API\Http.API.csproj -o ./publish -c Release
docker build  -f  .\src\Http.API\Dockerfile -t niltor/dev-center . 
# docker push dev-center

# docker run -p 8080:80 -d --name DevCenter -e ConnectionStrings__Default="Server=192.168.0.1;Port=5432;Database=DevCenter;User Id=postgres;Password=root;" niltor/dev-center

Set-Location $location