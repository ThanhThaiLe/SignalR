using chatbox.zapp.Models;
using chatbox.zapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatbox.zapp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;
        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }
        [HttpGet("check_api")]
        public IActionResult check_api()
        {
            return Ok("");
        }
        [HttpPost("register-user")]
        public IActionResult RegisterUser(UserModel model)
        {
            if (_chatService.AddUserToList(model.name))
            {
                return NoContent();
            }
            return BadRequest("This name is taken please choose anorther name");

        }
    }
}
