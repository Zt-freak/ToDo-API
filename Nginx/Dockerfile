FROM nginx

COPY ./Nginx/nginx.conf /etc/nginx/nginx.conf.tmp
RUN sed '1s/^\xEF\xBB\xBF//' < /etc/nginx/nginx.conf.tmp > /etc/nginx/nginx.conf