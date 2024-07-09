using Microsoft.AspNetCore.Mvc;
using RabitMQ.Producer.Services.RabitMq.Producer;
using System.Linq.Expressions;

namespace RabitMQ.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        IMessageProducer _messageProducer;
        public HomeController(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }
        [HttpPost]
        public IActionResult Post(string message)
        {
            try
            {
            _messageProducer.SendMessage(message);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
