# **📌 Kurumsal Mimaride MVC5 ile Blog Projesi**  

Bu proje, **N Katmanlı Mimari** ve **SOLID Prensipleri** kullanılarak geliştirilmiş **dinamik bir blog sitesidir**.  
Admin, yazar ve kullanıcı modülleri ile **tam kapsamlı bir içerik yönetim sistemi** sunmaktadır.  
PROJE CANLI LINKI [blokokog.com.tr](blokolog.com.tr)
**📌 Öne Çıkan Özellikler:**  
✅ **MVC5 ile Kurumsal Mimari Kullanımı**  
✅ **SOLID Prensiplerine Uygun Yapı**  
✅ **N Katmanlı Mimari (Entity, DataAccess, Business, Presentation)**  
✅ **Repository Design Pattern & Generic Repository Kullanımı**  
✅ **Yetkilendirme & Kimlik Doğrulama (Authentication & Authorization)**  
✅ **Dinamik Blog, Kategori ve Yorum Yönetimi**  
✅ **Yapay Zeka Destekli ChatBot (Google Gemini API Entegrasyonu)**  
✅ **Galeri Sayfası (Kendi Fotoğraflarınızı Yükleyin & Yönetin)**  
✅ **Admin Paneli ile Yönetim Kolaylığı**  
✅ **Pagination, Search, Validation & Session Kullanımı**  
---
!![resim_2025-03-21_183040732](https://github.com/user-attachments/assets/e499f11f-ed45-4ca8-a50a-a8ec3ab07224)
![resim_2025-03-21_183000162](https://github.com/user-attachments/assets/36540067-4dd1-4b37-8648-eef4fa3ed8c0)
![resim_2025-03-21_182943780](https://github.com/user-attachments/assets/985c2bd7-c04d-4e0e-a7e3-b866d8819ff5)
![resim_2025-03-21_182931417](https://github.com/user-attachments/assets/9187e750-44b5-404a-92af-d754ac9483fb)
![resim_2025-03-21_182912675](https://github.com/user-attachments/assets/1d1542cb-8a59-4dca-aa9c-7d459f4e0b0e)
![resim_2025-03-21_182853119](https://github.com/user-attachments/assets/c8c11c53-14bd-4094-b336-de1a22673b1f)
![resim_2025-03-21_182831601](https://github.com/user-attachments/assets/234fecb9-214a-4ca0-a11a-3894913ae5fb)
![resim_2025-03-21_182813614](https://github.com/user-attachments/assets/49b8dcc3-e16a-4967-bd3f-3bbf1f156c2c)
![resim_2025-03-21_182759609](https://github.com/user-attachments/assets/f8dc5846-346f-4ef2-a56a-4c7c20ff2de5)
![Kategor](https://github.com/user-attachments/assets/6921e202-3a71-493c-a800-4f692a763c9a)
![Footer](https://github.com/user-attachments/assets/79edb836-648c-4332-87f4-c18a4b2e7418)
![chatbot](https://github.com/user-attachments/assets/9cc590ea-f5bf-4878-af34-10b28453262c)
![anasayfa3](https://github.com/user-attachments/assets/e66ddbda-7ee7-44d4-ac20-e7aa6b38448f)
![Anasayfa2](https://github.com/user-attachments/assets/b8bf997b-04cb-4eb6-a5e8-b19d8d9c5858)
![AnaSayfa](https://github.com/user-attachments/assets/3b261820-9ce0-4ee1-b259-217ed91b2afe)
[proje resimleri]
---                                                  

## **📌 Proje Mimarisi**  
Bu projede **4 katmanlı mimari** kullanılmıştır:  

1️⃣ **EntityLayer** → Veritabanı tablolarına karşılık gelen sınıflar (**Blog, User, Admin, Category, Comment, Gallery**)  
2️⃣ **DataAccessLayer (DAL)** → **Entity Framework** ve **Repository Design Pattern** ile veri işlemleri  
3️⃣ **BusinessLayer (BLL)** → İş kurallarını içeren servisler (**Manager Sınıfları**)  
4️⃣ **PresentationLayer (UI - MVC)** → Kullanıcı arayüzü ve controller işlemleri  

---

## **📌 Proje Modülleri**  
### **👤 Kullanıcı Modülü**  
🔹 Blogları görüntüleyebilir ve kategorilere göre filtreleyebilir.  
🔹 Bloglara yorum yapabilir, puanlama bırakabilir.  
🔹 Arama ve sayfalama (pagination) desteği bulunmaktadır.  

### **✍️ Yazar Modülü**  
🔹 Yeni blog yazabilir ve mevcut yazılarını düzenleyebilir.  
🔹 Bloglarına gelen yorumları görebilir.  
🔹 Diğer yazarlara veya yöneticilere mesaj gönderebilir.  

### **👨‍💼 Admin Modülü**  
🔹 Blog, kategori, yazar ve yorumları yönetebilir.  
🔹 Yazarları aktif/pasif yapabilir veya rollerini değiştirebilir.  
🔹 Siteye gelen mesajları okuyabilir.  
🔹 ChatBot ve Galeri yönetimi yapabilir.  

---

## **📌 Kullanılan Teknolojiler**  

| Teknoloji | Açıklama |
|-----------|---------|
| **ASP.NET MVC5** | Web uygulaması geliştirme çerçevesi |
| **Entity Framework** | ORM (Object-Relational Mapping) katmanı |
| **SQL Server** | Veritabanı yönetim sistemi |
| **Bootstrap & jQuery** | Responsive ve dinamik arayüz |
| **Google Gemini API** | ChatBot entegrasyonu |
| **PagedList.Mvc** | Sayfalama işlemleri için |
| **AJAX & jQuery** | Asenkron veri işlemleri |

---

## **📌 Kurulum & Çalıştırma**  
### **1️⃣ Veritabanı Ayarları**  
1. **SQL Server'da `MyBlogDbE` adında bir veritabanı oluşturun.**  
2. `Web.config` dosyasında **connection stringi** kendi sunucunuza göre düzenleyin:  
```xml
<connectionStrings>
    <add connectionString="data source=YOUR_DB_NAME; initial catalog=YOUR_PRJ_NAME;UserID=YOUR_USER_ID;Password=YOUR_PASSWORD" 
         Name="Context" providerName="System.Data.SqlClient" />
</connectionStrings>
```
3. **Veritabanı tablolarını oluşturmak için** `Package Manager Console` üzerinde şu komutları çalıştırın:  
```sh
Enable-Migrations
Add-Migration InitialCreate
Update-Database
```

---

### **2️⃣ Projeyi Çalıştırma**  
📌 **Visual Studio veya Rider ile projeyi açın.**  
📌 **İlk olarak `PresentationLayer` projesini çalıştırın.**  
📌 **Varsayılan giriş sayfası:** `http://localhost:5000/Blog/Index`  

---

## **📌 Admin Paneli Kullanımı**  
**Admin Girişi İçin Varsayılan Bilgiler:**  
🔹 **Kullanıcı Adı:** `---`  
🔹 **Şifre:** `---`  

👨‍💼 **Admin paneline erişmek için:**  
➡ **`http://localhost:5000/Admin/Login`**  

---

## **📌 Eklenen Özellikler**  
### **🖼️ Galeri Modülü**  
📌 Kullanıcılar ve admin, **resim yükleyebilir, silebilir ve güncelleyebilir.**  
📌 **Popup ile resim büyütme, tam ekran görüntüleme ve geçiş efektleri eklendi.**  
📌 **Pagination (sayfalama) desteği ile resimler sayfalara bölündü.**  

### **🤖 ChatBot (Google Gemini API)**  
📌 Google Gemini API kullanılarak **dinamik bir sohbet botu** geliştirildi.  
📌 Kullanıcıların sorularına **yapay zeka destekli cevaplar veriyor.**  
📌 Chat bot **kendi öğrenme sistemine sahip ve akıllı yanıtlar üretiyor.**  

---

## **📌 Proje İçinde Öğreneceğiniz Konular**  
✔ **MVC Controller & View Kullanımı**  
✔ **Katmanlı Mimari ve Repository Pattern**  
✔ **Generic Repository ve Interface Kullanımı**  
✔ **Veritabanı CRUD İşlemleri**  
✔ **Entity Framework ile Code First Kullanımı**  
✔ **Model Validasyonu & Data Annotations Kullanımı**  
✔ **AJAX & jQuery Kullanımı**  
✔ **Session, Cookie ve Yetkilendirme İşlemleri**  
✔ **Dinamik Dashboard & Admin Paneli**  
✔ **Google Gemini API ile ChatBot Entegrasyonu**  
✔ **Galeri Yönetimi & Lightbox Popup Kullanımı**  

---

## **📌 Lisans & Katkıda Bulunma**  
🚀 **Bu projeyi kendi blog siteniz olarak kullanabilir veya geliştirmeye devam edebilirsiniz!**  
📌 **Projeye katkıda bulunmak için:**  
1. **Projeyi forklayın.**  
2. **Yeni bir branch oluşturun (`feature-ekleme`).**  
3. **Değişikliklerinizi yapın ve commit atın.**  
4. **Pull request gönderin!**  

---

## **📌Sonuç **  
✅ **Kurumsal mimariye uygun, ölçeklenebilir ve yönetilebilir bir blog platformu geliştirdik.**  
✅ **Admin, yazar ve kullanıcılar için özel modüller oluşturduk.**  
✅ **Projemize yapay zeka tabanlı bir ChatBot ekleyerek modernleştirdik.**  
✅ **Galeri modülü ile görselleri yönetilebilir hale getirdik.**  

📌 **Bu projeyi geliş![AnaSayfa](https://github.com/user-attachments/assets/4e4096a7-62c0-4c4a-ae6a-f0daf86ca6aa)
tirerek kendinize ait bir blog sitesi oluşturabilirsiniz!**  
📌 **Sorularınızı yorum olarak bırakabilir veya bana ulaşabilirsiniz.**  

