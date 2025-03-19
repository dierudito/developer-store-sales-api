using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Publishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using RabbitMQ.Client;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.Infra.Publishers;

public class RabbitMQEventPublisher(IConfiguration configuration, ILogger<RabbitMQEventPublisher> logger) : IEventPublisher
{
    public async Task PublishSaleCreatedEvent(SaleCreatedEvent saleCreatedEvent)
    {
        await PublishEventAsync(saleCreatedEvent, "sale_created");
    }

    public async Task PublishSaleModifiedEvent(SaleModifiedEvent saleModifiedEvent)
    {
        await PublishEventAsync(saleModifiedEvent, "sale_modified");
    }

    public async Task PublishSaleCancelledEvent(SaleCancelledEvent saleCancelledEvent)
    {
        await PublishEventAsync(saleCancelledEvent, "sale_cancelled");
    }

    public async Task PublishItemCancelledEvent(ItemCancelledEvent itemCancelledEvent)
    {
        await PublishEventAsync(itemCancelledEvent, "item_cancelled");
    }
    private async Task PublishEventAsync<T>(T @event, string queueName)
    {
        try
        {
            //var factory = new ConnectionFactory()
            //{
            //    HostName = configuration["RabbitMQ:HostName"],
            //    UserName = configuration["RabbitMQ:UserName"],
            //    Password = configuration["RabbitMQ:Password"]
            //};

            //using var connection = await factory.CreateConnectionAsync();
            //using var channel = await connection.CreateChannelAsync();
            //await channel.QueueDeclareAsync(queue: queueName,
            //                     durable: false,
            //                     exclusive: false,
            //                     autoDelete: false,
            //                     arguments: null);

            //var body = JsonSerializer.SerializeToUtf8Bytes(@event);

            //await channel.BasicPublishAsync(exchange: "",
            //                     routingKey: queueName,
            //                     body: body);

            logger.LogInformation("Event published to RabbitMQ: {EventName} - {QueueName}", @event.GetType().Name, queueName);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error publishing event to RabbitMQ: {EventName} - {QueueName}", @event.GetType().Name, queueName);            
        }
    }
}
