$location = Get-Location
cd  ../src/WebApp/Admin;
ng build -c production
scp  -r ./dist/admin/**/**  dev:/var/www/dev-center/
scp  -r ./dist/admin/**.*  dev:/var/www/dev-center/
cd $location