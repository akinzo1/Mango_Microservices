using EventBus.Events;
using Mango.EventBus.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.EventBusRabbitMQ
{
    public sealed class RabbitMQEventBus(
        ILogger<RabbitMQEventBus> logger,
        IServiceProvider serviceProvider, 
        IOptions<EventBusOptions> options, 
        IOptions<EventBusSubscriptionInfo> subscriptionOptions) : IEventBus, IDisposable, IHostedService
    {


        public Task PublishAsync(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
