# How to

## Building docker

```
docker build -f ./Dockerfile -t minitwitapi .
```

## Running docker

```
docker run -d -p 8000:80 --name minitwitapi minitwitapi
```

## Checking if it runs

Go to http://localhost:8000/

## Removing old container

docker rm minitwitapi

## Misc deploy commands

docker tag minitwitapi registry.digitalocean.com/devopsitu/minitwitapi:latest

docker push registry.digitalocean.com/devopsitu/minitwitapi:latest

doctl auth init

doctl registry login

docker pull registry.digitalocean.com/devopsitu/minitwitapi:latest
