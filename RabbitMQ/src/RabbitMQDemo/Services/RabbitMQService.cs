using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQDemo.Models;

namespace RabbitMQDemo.Services;

public interface IRabbitMQService
{
    void GetConnection();
    void CloseConnection();
    void DeclareExchange(Exchange exchange);

    void CreateQueu(QueuModel model);

    void QueuBind(string queuName,string exchangeName,string routingKey);
    void Publish(Publish publish);
    string Consume(string queuName);
}
public class RabbitMQService:IRabbitMQService
{
    private const string connectionString="amqp://guest:guest@localhost:5672/";
    private IConnection connection;
    private IModel channel;
    
    public void GetConnection()
    {
        ConnectionFactory connectionFactory = new ConnectionFactory()
        {
            Uri = new Uri(connectionString,UriKind.RelativeOrAbsolute),
            
        };
        connection= connectionFactory.CreateConnection();
        channel ??= connection.CreateModel();
    }

    public void CloseConnection()
    {
        connection.Close();
    }


    public void DeclareExchange(Exchange exchange)
    {
        channel.ExchangeDeclare(exchange.Name,exchange.Type);
    }

    public void CreateQueu(QueuModel model)
    {
        channel.QueueDeclare(model.Name,false,false);
    }

    public void QueuBind(string queuName,string exchangeName,string routingKey)
    {
        channel.QueueBind(queuName,exchangeName,routingKey);
    }

    public void Publish(Publish publish)
    {
        channel.BasicPublish(publish.Exchange,publish.RoutingKey,null,Encoding.UTF8.GetBytes(publish.Message));
    }

    public string Consume(string queuName)
    {
        var consumerEvent=new EventingBasicConsumer(channel);
        var messages = "";
        consumerEvent.Received += (ch, e) =>
        {
            var byteArray = e.Body.ToArray();
            messages=Encoding.UTF8.GetString(byteArray);
            Console.WriteLine(messages);
        };
        channel.BasicConsume(queuName, true, consumerEvent);
        return messages;
    }
}