
using EventBus.Events;

namespace Mango.EventBus.Abstractions;
public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event);
}