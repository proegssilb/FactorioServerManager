ARG envtype

FROM python:3.9 AS base
EXPOSE 8000
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        postgresql-client \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /usr/src/app
COPY entrypoint.sh requirements.txt ./
RUN pip install -r requirements.txt

FROM base AS code-prod
COPY . .

FROM base AS code-dev
VOLUME /usr/src/app

FROM code-${envtype}
CMD ["/bin/sh", "-c", "/usr/src/app/entrypoint.sh"]
