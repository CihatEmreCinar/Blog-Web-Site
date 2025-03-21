using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MyChatBotAPI.Models;
using Newtonsoft.Json;

namespace MyChatBotAPI.Controllers
{
    public class ChatController : ApiController
    {
        private readonly OpenAiService _openAiService = new OpenAiService();

        [HttpPost]
        [Route("api/chat")]
        public async Task<IHttpActionResult> Post([FromBody] ChatRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Message))
            {
                return BadRequest("Mesaj boş olamaz!");
            }

            var response = await _openAiService.GetChatResponseAsync(request.Message);
            return Ok(new ChatResponse { Response = response });
        }
    }
}
