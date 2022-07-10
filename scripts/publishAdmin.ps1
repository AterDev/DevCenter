
scp  -r ../src/WebApp/Admin/dist/admin/*  dev:/var/webapi/dev-center/
ssh dev sudo systemctl restart dev-center.service