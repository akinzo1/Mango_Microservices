using Mango.EventBus.Abstractions;
using Mango.Services.OrderAPI.Data;
using Mango.Services.OrderAPI.IntegrationEvents.Events;

namespace Mango.Services.OrderAPI.IntegrationEvents.EventHandling;

public class OrderStatusChangedToPaidIntegrationEventHandler(AppDbContext dbContext, ILogger<OrderStatusChangedToPaidIntegrationEventHandler> logger) : IIntegrationEventHandler<OrderStatusChangedToPaidIntegrationEvent>
{
    public async Task Handle(OrderStatusChangedToPaidIntegrationEvent @event)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", @event.Id, @event);


        foreach(var orderDetail in @event.OrderDetails)
        {
            logger.LogInformation("Handled integration event: {OrderDetail} - ({@IntegrationEvent})", orderDetail, @event);
            //do something
            dbContext.OrderDetails.Remove(orderDetail);
        }

        await dbContext.SaveChangesAsync();

    }
}

