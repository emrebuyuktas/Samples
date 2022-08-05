namespace RabbitMQDemo.Models;

public class Publish
{
    public string Exchange { get; set; }
    public string RoutingKey { get; set; }
    public string Message { get; set; }
}