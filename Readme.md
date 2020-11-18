# Pre-requisites 
* Docker installed

# Running the project

* Load up docker.  
* In commandline: `docker-compose up --build`

### Dev tools
A second Docker Compose file is added that allows browsing the data in redis and postgres. To execute, run in the commandline:
* `docker-compose -f .\compose-dev.yaml up -d --build`
* `docker-compose up --build`