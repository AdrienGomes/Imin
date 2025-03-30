# [16](https://github.com/AdrienGomes/Imin/issues/16) - Add backend infrastructure documentation

| Date | Name | Action |
|:----:|:----:|:------:|
|30/03/2025|AdrienGomes|Creation|

_Keywords :_ infrastructure, backend, server, docker, docker-compose

## Context

- Describing the backend infrastructure the application.

## Analysis

- The backend infrastructure is composed of a server **(iminbackend)** and a database **(postgres_backend)**.

```yaml
  iminbackend:
    restart: unless-stopped
    image: ${DOCKER_REGISTRY-}iminbackend
    build:
      context: .
      dockerfile: IMINBackend/Dockerfile
    environment:
      Postgres__Username: ${ENV_SERVER_DB_USERNAME}
      Postgres__Password: ${ENV_SERVER_DB_PASSWORD}
      Postgres__DbName: ${ENV_SERVER_DB_DBNAME}
    depends_on:
      postgres_backend:
        condition: service_healthy
    networks:
      - external_net

  postgres_backend:
    image: postgres:14.1-alpine
    restart: unless-stopped
    environment:
      POSTGRES_USER: ${ENV_SERVER_DB_USERNAME}
      POSTGRES_PASSWORD: ${ENV_SERVER_DB_PASSWORD}
      POSTGRES_DB: ${ENV_SERVER_DB_DBNAME}
    ports:
      - "5432:5432"
    volumes:
      - db-data-backend:/var/lib/postgresql/data
    healthcheck:
      test: ["CMD-SHELL", "pg_isready"]
      timeout: 5s
      interval: 10s
      retries: 30
    networks:
      - external_net
```
 - The server is built from a Dockerfile located in the IMINBackend folder. 
   - It requires the following environment variables:
     - ENV_SERVER_DB_USERNAME
     - ENV_SERVER_DB_PASSWORD
     - ENV_SERVER_DB_DBNAME
     
These variables are used to connect to the database. For _developpement_ a `.env` file is used to store these variables and injects them into the Docker container.
    
No ports are exposed for the server, it is only accessible from the network. The `docker-compose.override.yaml` exposes the server on port 8080 for _developpement_ purposes. 
The server is dependent on the database, it will only start if the database is healthy.
## Implementation - [16](https://github.com/AdrienGomes/Imin/pull/17)

## Test
- [X] Developpement server up and running
- [ ] Production server up and running
