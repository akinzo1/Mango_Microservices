using Mango.EventBus.Events;
using Mango.Services.OrderAPI.Models;

namespace Mango.Services.OrderAPI.IntegrationEvents.Events;
    public record OrderStatusChangedToPaidIntegrationEvent(int OrderId, IEnumerable<OrderDetails> OrderDetails) : IntegrationEvent;

