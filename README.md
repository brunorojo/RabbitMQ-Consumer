# RabbitMQ-Consumer

## Tecnologias:

- .Net 8
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Rabbit MQ 3.13](https://www.rabbitmq.com/docs/download)

## Instalação Docker Desktop

[Download Docker Desktop](https://www.docker.com/products/docker-desktop)

## Instalação RabbitMQ 3.13 (Docker Image)

```shell
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management  
```

## Login RabbitMQ:

URL: http://localhost:15672
Usuário/Senha: guest/guest

## COMANDOS: 

```shell
docker-compose up -d
```


