FROM rabbitmq:3-management-alpine

RUN rabbitmq-plugins enable --offline rabbitmq_management
RUN rabbitmq-plugins enable --offline rabbitmq_stomp rabbitmq_web_stomp rabbitmq_web_stomp_examples

RUN rabbitmq-plugins list

ENV RABBITMQ_CONFIG_FILE=/etc/rabbitmq/rabbitmq
ADD ./rabbitmq.conf /etc/rabbitmq/rabbitmq.conf
