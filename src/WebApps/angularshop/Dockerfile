#stage 1
FROM node:16-alpine3.15 as build
WORKDIR /usr/local/app
COPY ./ /usr/local/app
RUN npm install --legacy-peer-deps
RUN npm run build
#stage 2
FROM nginx
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/local/app/dist/angularshop /usr/share/nginx/html
EXPOSE 4200
