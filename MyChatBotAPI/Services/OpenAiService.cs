using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class OpenAiService
{
    private readonly string _apiKey = ConfigurationManager.AppSettings["OpenAIKey"];
    private readonly string _apiUrl = "https://api.openai.com/v1/chat/completions";

    public async Task<string> GetChatResponseAsync(string userMessage)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var requestBody = new
            {
                model = "gpt-4",
                messages = new[]
                {
                    new { role = "system", content = "Sen bir yardımcı asistanısın." },
                    new { role = "user", content = userMessage }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_apiUrl, content);
            var result = await response.Content.ReadAsStringAsync();

            dynamic jsonResponse = JsonConvert.DeserializeObject(result);
            return jsonResponse.choices[0].message.content;
        }
    }
}
