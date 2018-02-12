FROM rabbitmq:3-management-alpine

RUN rabbitmq-plugins enable --offline rabbitmq_management
RUN rabbitmq-plugins enable --offline rabbitmq_mqtt rabbitmq_web_mqtt
RUN rabbitmq-plugins enable --offline rabbitmq_stomp rabbitmq_web_stomp

RUN rabbitmq-plugins list