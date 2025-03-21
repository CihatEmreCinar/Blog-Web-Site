using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace API.Controllers
{
    public class ChatController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        // 📌 Sayfa açıldığında ilk olarak GET isteğini yapıp ViewBag'e atıyoruz
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Index2()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:5000/api/chat");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);
                ViewBag.WelcomeMessage = jsonResponse.response;
            }
            catch (Exception ex)
            {
                ViewBag.WelcomeMessage = "API isteği başarısız: " + ex.Message;
            }

            return View();
        }

        // 📌 Kullanıcı mesaj gönderdiğinde POST isteği yapıyoruz ve cevabı ViewBag'e atıyoruz
        [HttpPost]
        public async Task<ActionResult> Index(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                ViewBag.BotResponse = "Boş mesaj gönderilemez!";
                return View();
            }

            var requestBody = new { message = message };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/api/chat", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);
                ViewBag.BotResponse = jsonResponse.response;
            }
            catch (Exception ex)
            {
                ViewBag.BotResponse = "API isteği başarısız: " + ex.Message;
            }

            return View();
        }
    }
}
