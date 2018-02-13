FROM rabbitmq:3-management-alpine

RUN rabbitmq-plugins enable --offline rabbitmq_management
RUN rabbitmq-plugins enable --offline rabbitmq_mqtt rabbitmq_web_mqtt rabbitmq_web_mqtt_examples

RUN rabbitmq-plugins list

ENV RABBITMQ_CONFIG_FILE=/etc/rabbitmq/rabbitmq
ADD ./rabbitmq.conf /etc/rabbitmq/rabbitmq.conf
