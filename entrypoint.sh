#!/bin/bash
set -euo pipefail

if [ -n "${APP_DEBUG}" ]; then
    python manage.py makemigrations
    python manage.py migrate
    exec python ./manage.py runserver 0:8000
else
    exec daphne -b 0.0.0.0 'FactorioServerManager.asgi:application'
fi
