This readme is intended for those who develop this application, not for use of the application itself.

# Pre-requisites 
* Docker installed

# Running the project

* Load up docker.  
* In commandline: `docker-compose up --build`

## Dev tools
A second Docker Compose file is added that allows browsing the data in redis and postgres. To execute, run in the commandline:
* `docker-compose -f .\compose-dev.yaml up -d --build`
* `docker-compose up --build`

You can browse the **postgres** database via pgAdmin by connecting to `http://localhost:8082`

## Development Architecture
* Frontend application: **Javascript React**
* Backend application: **Python Django**
* Database: **Postgres SQL** and **Redis**
