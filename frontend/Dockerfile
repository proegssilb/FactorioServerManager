ARG envtype

FROM node:lts-alpine AS react-base
WORKDIR /app
ENV PATH /app/node_modules/:/mnt/modules/.bin:$PATH
COPY package.json ./
COPY yarn.lock ./

# FROM react-base AS react-dev
# RUN mkdir /mnt/modules && yarn --modules-folder /mnt/modules install
# VOLUME /app
# CMD ln -s /mnt/modules /app/node_modules && exec yarn start

FROM react-base AS react-build
RUN yarn install
COPY . ./
RUN yarn build

FROM nginx:stable-alpine AS react-prod
ENV NGINX_PORT 3000
COPY --from=react-build /app/build /usr/share/nginx/html
COPY templates/ /etc/nginx/templates
CMD ["nginx", "-g", "daemon off;"]

FROM react-${envtype}
EXPOSE 3000