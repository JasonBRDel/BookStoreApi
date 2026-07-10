using Messaging.Common.Events;

namespace OrderService.Contracts.Messaging
{
    internal interface IOrderEventPublisher
    {
        Task PublishOrderPlacedAsync(OrderPlacedEvent evt, string? correlationId = null);
    }
}
