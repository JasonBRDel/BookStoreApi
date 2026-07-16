using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BookStoreWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConnection _connection;
        private IChannel _channel;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
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

                await _channel.QueueDeclareAsync
                    (
                        queue: "inventory_queue",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null,
                        cancellationToken: cancellationToken
                    );

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
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    _logger.LogInformation($"[x] Received: {message}");

                    // Simulate work
                    await Task.Delay(500, stoppingToken);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message.");

                }

            };

            // Start consuming
            await _channel.BasicConsumeAsync(
                queue: "inventory_queue",
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
