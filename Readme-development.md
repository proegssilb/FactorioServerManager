This readme is intended for those who develop this application, not for use of the application itself.

# Pre-requisites 
* Docker installed

# Running the project

* Load up docker.  
* In commandline: `docker-compose up --build`  
* Wait a bit  
* When ready, the application will be available at http://localhost:8000/  

## Dev tools
A second Docker Compose file is added that allows browsing the data in redis and postgres. To execute, run in the commandline:
* `docker-compose -f .\compose-dev.yaml up -d --build`
* `docker-compose up --build`

You can browse the **postgres** database via pgAdmin by connecting to `http://localhost:8082`

## Development Architecture
* Frontend application: **Javascript React**
* Backend application: **Python Django**
* Database: **Postgres SQL** and **Redis**

### Folder structure
**FactorioServerManager** -- The main Django project. Includes overall settings.  
**auth0login** -- supporting Django app. Handles authentication.  
**calendars** -- supporting Django app. Handles calendars.  
**frontend** -- React app. Handles the frontend and .html pages.  
**games** -- supporting Django app.  
**servers** -- supporting Django app.  
