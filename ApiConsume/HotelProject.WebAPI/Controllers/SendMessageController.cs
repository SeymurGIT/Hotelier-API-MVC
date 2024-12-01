using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }
        [HttpGet]
        public IActionResult SendMessagesList()
        {
            var sentMessagesList = _sendMessageService.TGetList();
            return Ok(sentMessagesList);
        }
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return Ok();

        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TInsert(sendMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var sentMessageToGet = _sendMessageService.TGetById(id);
            return Ok(sentMessageToGet);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var expectedId = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(expectedId);
            return Ok();
        }
        [HttpGet("GetSentMessagesCount")]
        public IActionResult GetSentMessagesCount()
        {
            return Ok(_sendMessageService.TGetSentMessagesCount());
        }
    }
}
