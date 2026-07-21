using BookStoreWorkerService.DAL;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BookStoreWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IConnection _connection;
        private IChannel _channel;
        private readonly string inventoryQueue = "inventory_queue";
        private readonly string bookStoreExchange = "bookstore_exchange";
        private readonly string orderPlaced = "order.placed";
        private readonly string orderCancelled = "order.cancelled";
        private readonly string orderCompleted = "order.completed";

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        private async Task InitializeRabbitMq(CancellationToken cancellationToken)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest",
                    VirtualHost = "bookstore_vhost",
                    ConsumerDispatchConcurrency = 1
                };

                _connection = await factory.CreateConnectionAsync(cancellationToken);
                _channel = await _connection.CreateChannelAsync();

                await _channel.ExchangeDeclareAsync
                (
                    exchange: bookStoreExchange,
                    type: ExchangeType.Topic,
                    durable: true,
                    autoDelete: false,
                    arguments: null,
                    cancellationToken: cancellationToken
                );

                await _channel.QueueDeclareAsync
                    (
                        queue: inventoryQueue,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null,
                        cancellationToken: cancellationToken
                    );

                // Bind queue to multiple routing keys
                await _channel.QueueBindAsync(inventoryQueue, bookStoreExchange, orderPlaced, cancellationToken: cancellationToken);
                await _channel.QueueBindAsync(inventoryQueue, bookStoreExchange, orderCancelled, cancellationToken: cancellationToken);

                _logger.LogInformation("RabbitMQ async connection established.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initializing RabbitMQ connection.");
                throw;
            }
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await InitializeRabbitMq(stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (sender, ea) =>
            {
                try
                {
                    var routingKey = ea.RoutingKey;
                    var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                    _logger.LogInformation("Received message with routing key {RoutingKey}: {Message}", routingKey, message);

                    using var scope = _serviceScopeFactory.CreateScope();
                    var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();

                    if (routingKey == orderPlaced)
                    {
                        await orderRepository.CreateOrder(message, stoppingToken);
                        _logger.LogInformation($"Order inserted");
                    }
                    else if (routingKey == orderCancelled) {
                        //logic here for delete order
                    }
                    else if(routingKey == orderCompleted)
                    {
                        //logic here for delete order
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message.");

                }

            };

            // Start consuming
            await _channel.BasicConsumeAsync(
                queue: inventoryQueue,
                autoAck: true,
                consumer: consumer,
                cancellationToken: stoppingToken
            );

            // Keep the worker alive
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }

}
