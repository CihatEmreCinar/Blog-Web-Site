using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MyBlogE.Controllers
{
    [AllowAnonymous]
    public class ChatController : Controller
    {
        private readonly string _apiKey = ConfigurationManager.AppSettings["GeminiApiKey"];

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetChatResponse(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return Json(new { response = "Mesaj boş olamaz!" });
            }

            try
            {
                string modelName = "gemini-1.5-flash";
                string apiUrl = $"https://generativelanguage.googleapis.com/v1/models/{modelName}:generateContent?key={_apiKey}";

                using (var client = new HttpClient())
                {
                    // 📌 Mini Blog hakkında ön bilgi ekleyerek Gemini'yi özelleştireceğiz.
                   string blogInfo = @"
Sen bir blog yönetim asistanısın. Aşağıda bir blog sitesinde bulunan kategoriler ve blog başlıkları listelenmiştir. 
Blog sitesi, ziyaretçilere geniş bir bilgi yelpazesi sunmak amacıyla bu kategorilere göre düzenlenmiştir.
Sana verilen bilgiler doğrultusunda, her kategoriye uygun içerik önerileri oluşturabilir,
içerikleri organize edebilir ve kullanıcı sorularına uygun öneriler sunabilirsin. senden ne isteniyorsa sadece onu ver. eğer birisi sadece kategorilerin ne olduğunu sorduysa sadece kategorileri öğrenmek istiyordur. bunun sonrasında şunu yönelte bilirsin blog başlıklarını daincelemek ister misiniz? Hangi kategori için blog başlığı istersiniz ?

Kategoriler:
Film Dizi
Yenilik
Keşif
Macera
Seyahat
Spor
Yazılım
Oyun
Teknoloji
Kültür Sanat

Blog Başlıkları:
Yapay Zeka ve Geleceği Hakkında Yorumlar
Seyahat Rehberi: Bali
Film İncelemesi: Inception
Merhaba Dünya Kodlamada İlk Adım
Teknoloji ve Geleceğimiz
Doğal Yaşam ve Sağlık
Yeni Nesil Oyunlar
Fitness ve Spor Rehberi
İtalyanın Harika Şehri: Roma
Aşıklar Şehri: Paris
Efsanevi Kimyager Walter White
Yapay Zeka ve Günlük Hayat
Sanat ve Yaratıcılık
Uzay Keşifleri
Blockchain ve Kripto Paralar
Yeni Nesil Elektrikli Araçlar
Tokyo Olimpiyatları: Efsanevi Olimpiyat 2020
Doğayla İç İçe O Muhteşem Spor: Trekking
İzmirin İncisi: Efes Antik Kenti
Tarih ve Kültür
Yemek Tarifleri ve Beslenme
Oscar Ödüllü Yol Macerası
Seyahat Rotaları
Tuhaf Bir Dizi
Beklenen Samuray: Assassin's Creed Shadows
Yapay Zekada Dönüm: Open AI Chat GPT
Efsanevi Keşif: Göbekli Tepe
İşte O Beklenen Dizi: Yıldızların Çöküşü
Görevlerin:
Her kategoriye uygun yeni blog içerikleri öner.
Kullanıcı sorularına göre bu başlıkları veya kategorileri ilişkilendirerek bilgi sun.
Blog yazılarına uygun giriş cümleleri oluştur.
Ziyaretçilere blog önerileri sunarak sitenin trafiğini artırmaya yardımcı ol.
Sana sorulan sorular doğrultusunda kategorilerden ve başlıklardan en uygun olanları seçip, detaylı açıklamalar yapabilirsin. Amacın, hem kullanıcı deneyimini geliştirmek hem de içeriklerin görünürlüğünü artırmaktır.
Sitedeki içerikler, aşağıdaki yazarlar tarafından hazırlanır:

- **Ender Serez**: Aile bağları ve toplumsal değerleri işleyen duygusal hikayeler yazar.  
- **Mira Beylice**: Gençlik, aşk ve özgürlük temalarında yazılar yazan bir yazar.  
- **Selim Serez**: Adalet ve etik üzerine düşündüren eserler yazar.  
- **Yaman Koper**: Mücadele ve azim temalı hikayeleri ile tanınır.  
- **Mert Asım Serez**: Gençlik ve dostluk üzerine mizahi bakış açısıyla yazılar kaleme alır.  
- **Orkun Civanoğlu**: Güç ve hırs temalı gerilim hikayeleri yazar.  
- **Eylül Buluter**: Özgürlük ve hayallerin peşinden gitme temalarını işler.  
- **Sedef Kaya**: Doğa ve insan ilişkisini anlatan huzur verici içerikler oluşturur.  
- **Beren Beylice**: Ruhsal yolculuklar ve kişisel dönüşümler üzerine yoğunlaşan eserler yazar.

Eğer birisi Mini Blog hakkında bilgi almak isterse, ona blogun yapısını, yazarlarını ve içerik konularını anlat. 
Eğer bir kategori veya yazar hakkında özel bir soru sorulursa, ona doğru bilgiyi ver.
Eğer doğrudan bir blog yazısı hakkında bilgi isterse, ona en alakalı içerikleri öner.
Bloglarda karmaşık sorular gelebilir kullanıcının asıl istediği şeye odaklanıp net olman esastır.
Kibar ve naziklik esastır.
Benim yapmış olduğum blog sitesi haricinde sorulara cevap vermiyorsun ve kişileri blog ile ilgili konulara yönlendiriyorsun.
Eğer sitede istenilen blog ile ilgili bir başlık yoksa o başlığı dikkate alacağımızı ve kişiyi önemsediğimizi belirteceğiz.

";

                    var requestBody = new
                    {
                        contents = new[]
                        {
                            new { role = "user", parts = new[] { new { text = blogInfo } } },
                            new { role = "user", parts = new[] { new { text = "Kullanıcının sorusu: " + message } } }
                        }
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);
                    var result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return Json(new { response = "API hatası: " + response.StatusCode + " - " + result });
                    }

                    dynamic jsonResponse = JsonConvert.DeserializeObject(result);
                    string geminiResponse = jsonResponse.candidates[0].content.parts[0].text;

                    return Json(new { response = geminiResponse });
                }
            }
            catch (Exception ex)
            {
                return Json(new { response = "Hata oluştu: " + ex.Message });
            }
        }
    }
}
