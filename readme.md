# Message Broker & .Net Core - Introdução ao RabbitMQ 

## [Evento no Facebook do Canal .NET](https://www.facebook.com/events/1689216434472736/)
 Transmissão ao vivo Quinta-feira, pós carnaval, dia 15/Fev/2018

## Demos

### [/standalone](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone)
Esses são exemplos de setup do RabbitMQ. A intenção desses exemplos é apresentar como subir um novo RabbitMQ de diversas formas, usando docker. Os exemplos são incrementais (o exemplo 2 adiciona alguma feature ao exemplo 1 e assim sucessivamente).

> ### [/standalone/01-ports](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone/01-ports)
> Primeiro exemplo com usuário senha e portas

> ### [/standalone/02-vhost](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone/02-vhost)
> Segundo exemplo já com Virtual Host configurado

> ### [/standalone/03-volume](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone/03-volume)
> Terceiro exemplo, agora com o Volume do Mnesia (database usado pelo RabbitMQ)

> ### [/standalone/04-plugins](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone/04-plugins)
> Quarto exemplo, utiliza um dockerfile para habilitar os plugins:
> * [rabbitmq_management](https://www.rabbitmq.com/management.html)
> * [rabbitmq_mqtt](https://www.rabbitmq.com/mqtt.html)
> * [rabbitmq_web_mqtt](https://www.rabbitmq.com/web-mqtt.html)
> * [rabbitmq_stomp](https://www.rabbitmq.com/stomp.html)
> * [rabbitmq_web_stomp](https://www.rabbitmq.com/web-stomp.html)

