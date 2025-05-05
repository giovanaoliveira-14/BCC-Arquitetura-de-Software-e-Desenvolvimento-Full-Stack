using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using MessageReceiverAPI.Models;
using MessageReceiverAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MessageReceiverAPI.Services;

public class RabbitMQConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;
   private IConnection _connection;
    private IModel _channel;


    public RabbitMQConsumer(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    private void SetupRabbitMQConnection()
    {
        var factory = new ConnectionFactory()
        {
            Uri = new Uri(_configuration.GetValue<string>("RabbitMQ:ConnectionString"))
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "myqueue", durable: true, exclusive: false, autoDelete: false, arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        SetupRabbitMQConnection();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (sender, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            using (var scope = _serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var data = JsonConvert.DeserializeObject<GenericData>(message);
                if (data != null)
                {
                    db.GenericData.Add(data);
                    db.SaveChanges();
                }
            }
        };

        _channel.BasicConsume(queue: "myqueue", autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _channel?.Close();
        _connection?.Close();
        await base.StopAsync(cancellationToken);
    }
}
