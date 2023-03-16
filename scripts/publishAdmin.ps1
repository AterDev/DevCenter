$location = Get-Location
cd  ../src/Http.API/ClientApp;
ng build -c production
scp  -r ./dist/**/**  dev:/var/www/dev-center/
scp  -r ./dist/**.*  dev:/var/www/dev-center/
cd $location