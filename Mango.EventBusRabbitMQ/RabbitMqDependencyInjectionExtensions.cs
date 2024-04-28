using Mango.EventBus.Abstractions;
using Microsoft.Extensions.Hosting;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Mango.EventBusRabbitMQ;

public static class RabbitMqDependencyInjectionExtensions
{
    // {
    //   "EventBus": {
    //     "SubscriptionClientName": "...",
    //     "RetryCount": 10
    //   }
    // }

    private const string SectionName = "EventBus";

    public static IEventBusBuilder AddRabbitMqEventBus(this IHostApplicationBuilder builder, string connectionName)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddMassTransit(x =>
        {
            // elided...

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri("amqp://guest:guest@127.0.0.1:5672"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                    h.ConnectionName(connectionName);
                });
                
                cfg.ConfigureEndpoints(context);
            });
        });

        // Options support
        //builder.Services.Configure<EventBusOptions>(builder.Configuration.GetSection(SectionName));

        // Abstractions on top of the core client API
        builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>();
      
        // Start consuming messages as soon as the application starts
        builder.Services.AddSingleton<IHostedService>(sp => (RabbitMQEventBus)sp.GetRequiredService<IEventBus>());

        return new EventBusBuilder(builder.Services);

        //builder.AddRabbitMQClient(connectionName, configureSettings: settings =>
        //{
        //    settings.ConnectionString = "amqp://guest:guest@127.0.0.1:5672";
        //}, configureConnectionFactory: factory =>
        //{
        //    ((ConnectionFactory)factory).DispatchConsumersAsync = true;
        //});

    }
    private class EventBusBuilder(IServiceCollection services) : IEventBusBuilder
    {
        public IServiceCollection Services => services;
    }
}
