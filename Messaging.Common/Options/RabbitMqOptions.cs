namespace Messaging.Common.Options
{
    public sealed class RabbitMqOptions
    {
        // Connection
        public string HostName { get; set; } = "localhost";
        public int Port { get; set; } = 5672;
        public string UserName { get; set; } = "bookstore_user";
        public string Password { get; set; } = "admin";
        public string VirtualHost { get; set; } = "bookstore_vhost";
        // Exchange(s)
        public string ExchangeName { get; set; } = "bookstore_exchange";
        // Dead-lettering (optional but recommended)
        public string? DlxExchangeName { get; set; } = "bookstore_dlx";
        public string? DlxQueueName { get; set; } = "bookstore_dlq";
        // Queues we care about for this feature set
        public string ProductOrderPlacedQueue { get; set; } = "product.order_placed";
        public string NotificationOrderPlacedQueue { get; set; } = "notification.order_placed";
    }
}
