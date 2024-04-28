
namespace Mango.EventBusRabbitMQ;

public class EventBusOption
{
    public string SubscriptionClientName { get; set; }
    public int RetryCount { get; set; } = 10;
}

