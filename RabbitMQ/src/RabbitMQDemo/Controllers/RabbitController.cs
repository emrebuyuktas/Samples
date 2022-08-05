using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQDemo.Models;
using RabbitMQDemo.Services;

namespace RabbitMQDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RabbitController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMqService;

        public RabbitController(IRabbitMQService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }
        [HttpGet]
        public IActionResult CreateConnection()
        {
            _rabbitMqService.GetConnection();
            return Ok("Connected");
        }
        [HttpGet]
        public IActionResult CloseConnection()
        {
            _rabbitMqService.CloseConnection();
            return Ok("Closed");
        }
        
        
        [HttpPost]
        public IActionResult CreateExchange([FromBody]Exchange exchange)
        {
            _rabbitMqService.DeclareExchange(exchange);
            return Created("",exchange);
        }
        
        [HttpPost]

        public IActionResult CreateQueu([FromBody]QueuModel model)
        {
            _rabbitMqService.CreateQueu(model);
            return Created("", model);
        }

        [HttpGet]
        public IActionResult BindQueu(string queuName,string exchangeName,string routingKey)
        {
            _rabbitMqService.QueuBind(queuName,exchangeName,routingKey);
            return Ok();
        }

        [HttpPost]
        public IActionResult Publish([FromBody]Publish publish)
        {
            _rabbitMqService.Publish(publish);
            return Ok();
        }

        [HttpGet]
        public IActionResult Consume(string queuName)
        {
            return Ok(_rabbitMqService.Consume(queuName));
        }
    }
}
