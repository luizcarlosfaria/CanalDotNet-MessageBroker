using System;
using System.Linq;
using System.Collections.Generic;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;

namespace AMQP.Exemplo
{
    class Program
    {
        const int producerCount = 1;
        const int consumerCount = 10;

        const int produceAmount = 500_000;

        static void Main(string[] args)
        {
            EnsureResourceCreation();

            for (int threadCount = 1; threadCount <= producerCount; threadCount++)
            {
                (new System.Threading.Thread(new System.Threading.ThreadStart(Producer))).Start();
            }

            //Espera 30 segundos para começar a processar
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));

            for (int threadCount = 1; threadCount <= consumerCount; threadCount++)
            {
                (new System.Threading.Thread(new System.Threading.ThreadStart(Consumer))).Start();
            }
        }

        /// <summary>
        /// Envia X mensagens (em plain text) para a exchange "minha_exchange" usando routing key "app"
        /// </summary>
        static void Producer()
        {
            using (IConnection connection = BuildConnection())
            {
                using (IModel model = connection.CreateModel())
                {
                    for (long seq = 1; seq < produceAmount; seq++)
                    {

                        byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes($"Hello, world! NUM {seq}");

                        IBasicProperties props = model.CreateBasicProperties();
                        props.ContentType = "text/plain";
                        props.DeliveryMode = 2;
                        props.Headers = new Dictionary<string, object>
                        {
                            { "latitude", 51.5252949 },
                            { "longitude", -0.0905493 }
                        };

                        model.BasicPublish(exchange: "minha_exchange",
                                           routingKey: "app",
                                           basicProperties: props,
                                           body: messageBodyBytes);

                    }
                }
            }
            Console.WriteLine($"Foram enviadas {produceAmount} mensagens para a fila");
        }


        /// <summary>
        /// Consome Mensagens da Fila
        /// </summary>
        static void Consumer()
        {
            IConnection connection = BuildConnection();
            IModel model = connection.CreateModel();
            var consumer = new EventingBasicConsumer(model);
            consumer.Received += (channel, deliverEventArgs) =>
            {
                var body = deliverEventArgs.Body;
                Console.Write(".");
                model.BasicAck(deliverEventArgs.DeliveryTag, false);
            };
            String consumerTag = model.BasicConsume("queue1_work", false, consumer);
        }

        #region Infra

        private static void EnsureResourceCreation()
        {
            using (IConnection connection = BuildConnection())
            {
                using (IModel model = connection.CreateModel())
                {
                    model.ExchangeDeclare(
                        exchange: "minha_exchange",
                        type: "topic",
                        durable: false,
                        autoDelete: false,
                        arguments: null);
                    
                    model.QueueDeclare(
                        queue: "queue1_work",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    
                    model.QueueBind(
                        queue: "queue1_work", 
                        exchange:"minha_exchange",
                        routingKey: "app");
                }
            }
        }

        private static IConnection BuildConnection()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "usuario",
                Password = "senha",
                VirtualHost = "exemplo_amqp",
                HostName = "rabbitmq",
                Port = 5672,
                AutomaticRecoveryEnabled = true
            };

            IConnection conn = null;
            int retryCount = 0;
            do
            {

                try
                {
                    conn = factory.CreateConnection();
                }
                catch (BrokerUnreachableException rootException) when (DecomposeExceptionTree(rootException).Any(it => it is ConnectFailureException && (it?.InnerException?.Message?.Contains("Connection refused") ?? false)))
                {
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds((retryCount + 1) * 2));
                }
                catch
                {
                    throw;
                }

            } while (conn == null && ++retryCount <= 5);
            if (conn == null)
                throw new InvalidOperationException($"Não foi possível conectar ao RabbitMQ após {retryCount} tentativas");
            return conn;
        }


        public static IEnumerable<Exception> DecomposeExceptionTree(Exception currentException)
        {
            while (currentException != null)
            {
                yield return currentException;
                currentException = currentException.InnerException;
            }
        }

        #endregion
    }
}

