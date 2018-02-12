# Message Broker & .Net Core - Introdução ao RabbitMQ 

## [Evento no Facebook do Canal .NET](https://www.facebook.com/events/1689216434472736/)
 Transmissão ao vivo Quinta-feira, pós carnaval, dia 15/Fev/2018

## Demos

### [/standalone](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone)
Diversos exemplos de setup do RabbitMQ com docker. Os exemplos são incrementais, onde o exemplo 2, adiciona alguma feature ao exemplo 1 e assim sussesivamente.

#### [/standalone/01-ports](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone/01-ports)
Primeiro exemplo com usuário senha e portas

#### [/standalone/02-vhost](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone/02-vhost)
Segundo exemplo já com Virtual Host configurado

#### [/standalone/03-volume](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone/03-volume)
Terceiro exemplo, agora com o Volume do Mnesia (database usado pelo RabbitMQ)

#### [/standalone/04-plugins](https://github.com/luizcarlosfaria/CanalDotNet-MessageBroker/tree/master/standalone/04-plugins)
Quarto exemplo, agora com um dockerfile, habilitando diversos plugins. Entre eles MQTT e STOMP



