FROM nginx as base
WORKDIR /var/source/admin
COPY src/WebApp/Admin/nginx.config /etc/nginx/nginx.conf

FROM node:16-alpine as build
WORKDIR /var/source/admin
COPY src/WebApp/Admin/ /var/source/admin/
RUN npm ci
RUN npm run build -c=production

FROM base as final
WORKDIR /usr/share/nginx/html
COPY --from=build /var/source/admin/dist/admin .
EXPOSE 80