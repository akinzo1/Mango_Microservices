
using Microsoft.Extensions.DependencyInjection;

namespace Mango.EventBus.Abstractions;
public interface IEventBusBuilder
{
    public IServiceCollection Services { get; }
}
