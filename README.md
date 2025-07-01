# 🚗 CarBook Projesi

## 🌐 Projeye Genel Bakış

CarBook, araç kiralama süreçlerini hem kullanıcılar hem de yöneticiler için kolaylaştırmayı hedefleyen, dinamik ve işlevsel bir web uygulamasıdır. Kullanıcılar, araçları lokasyon bazlı filtreleyerek listeleyebilir, detaylı bilgilerine erişebilir ve rezarvasyon işlemlerini hızlıca gerçekleştirebilirler. Yöneticiler, sistemin tüm bileşenlerini admin paneli üzerinden merkezi olarak yönetebilirler.

---

## 🧰 Kullanılan Teknolojiler

### 💻 Backend Teknolojileri

* **ASP.NET Core 8.0 (MVC & Web API):** Uygulamanın temel çatısını oluşturur. API ve UI katmanları bu yapı üzerinde geliştirilmiştir.
* **Entity Framework Core (Code First Yaklaşımı):** Veritabanı işlemleri için kullanılmış ve veri modelleri üzerinden otomatik migration işlemleri gerçekleştirilmiştir.
* **Microsoft SQL Server (MSSQL):** Tüm verilerin güvenli ve ilişkisel şekilde saklandığı veritabanıdır.
* **LINQ:** Veri sorgulama işlemlerinde kullanılarak kod okunabilirliği artırılmıştır.

### 🧱 Yazılım Mimarisi ve Desenleri

* **Onion Architecture:** Katmanlı yapı sayesinde iş, veri ve sunum katmanları birbirinden ayrılarak sürdürülebilir bir yapı sağlanmıştır.
* **CQRS (Command Query Responsibility Segregation):** Sorgu ve komut işlemleri ayrıştırılarak daha temiz ve performanslı bir yapı elde edilmiştir.
* **MediatR (Mediator Design Pattern):** Katmanlar arası gevşek bağlılık sağlanarak kod tekrarları azaltılmıştır.
* **Repository Design Pattern:** Veri erişim katmanında soyutlama sağlanmış, test edilebilirlik ve genişletilebilirlik artırılmıştır.

### 🔐 Güvenlik ve Doğrulama

* **JWT (JSON Web Token):** Kullanıcı kimlik doğrulaması ve yetkilendirme işlemleri için kullanılmıştır.
* **FluentValidation:** Giriş verilerinin kontrolü için güçlü ve esnek bir doğrulama sistemi entegre edilmiştir.

### 🌐 Gerçek Zamanlı İletişim

* **SignalR:** Kullanıcıların sistemde gerçekleştirdiği bazı işlemlerin anlık bildirimler ile iletilmesi sağlanmıştır.

### 🎨 Ön Yüz ve UI Bileşenleri

* **HTML, CSS, JavaScript:** Projenin temel web arayüzünü oluşturur.
* **Bootstrap:** Responsive ve modern tasarımlı kullanıcı arayüzleri için kullanılmıştır.
* **View Components & Areas:** ASP.NET MVC yapısı içerisinde modüler ve bölgesel tasarım için tercih edilmiştir.
* **SweetAlert:** Uyarı, bildirim ve onay kutuları için kullanıcı dostu animasyonlu alert kutuları sağlanmıştır.
* **Pivot Table (Özelleştirilmiş veri görselleştirme):** Özellikle admin panelde dinamik veri sunumu ve analiz için kullanılmıştır.

---

## 🖥️ Kullanıcı Paneli

CarBook’un kullanıcı arayüzü, modern ve duyarlı bir tasarım anlayışıyla geliştirildi. Kullanıcıların araç kiralama deneyimini kolaylaştıran, sade ama işlevsel bir yapı sunar. Arayüzde kullanılan tüm formlar, FluentValidation destekli giriş kontrolleri ile güçlendirilmiştir.

### 👥 Kullanıcıların Yapabilecekleri

* Araçları listeleme ve lokasyona göre filtreleme
* Günlük, haftalık, aylık fiyat bilgilerine göre ödeme türü seçimi
* Araç detay sayfalarında teknik bilgilere ulaşma
* Araçlar hakkında yorum yapma ve diğer yorumları inceleme
* Giriş yaparak araçlar için rezervasyon oluşturma
* Yazarlar tarafından eklenen blog içeriklerini okuma ve yorum yapma
* İletişim paneli üzerinden mesaj gönderme
* Referans yorumlarını görüntüleme

### 💡 Teknik Özellikler

* `wwwroot` dizini altındaki özel tasarımlı CarBook-master şablonu üzerine kuruldu.
* Sayfalarda çoklu veri gösterimlerinde pagination (sayfalandırma) sistemi kullanıldı.
* Blog ve bazı listeleme sayfalarında AJAX tabanlı dinamik sayfa yükleme yapıldı.
* Tüm kullanıcı etkileşimli alanlarda input validation uygulanmıştır.

---

## 🛠️ Admin Paneli

Admin paneli, tüm içeriğin merkezi olarak yönetilebildiği kapsamlı ve esnek bir yapıya sahiptir. Projede CRUD işlemlerine dayalı geliştirilmiş bu panel sayesinde yöneticiler, sistemin her alanını hızlıca yönetebilir.

### 🧾 Yönetilebilir Modüller

* Araçlar, özellikleri ve fiyat bilgileri
* Lokasyonlar
* Markalar ve modeller
* Blog yazarları, içerikleri ve kategoriler
* Kullanıcı yorumları ve referanslar
* Ödeme türleri (günlük / haftalık / aylık)
* Hakkımızda, iletişim, sosyal medya alanları
* Banner ve alt adres gibi site tasarımı alanları

### 📊 Ekstra Özellikler

* Dashboard’da istatistik takibi (Bazı veriler SignalR ile anlık olarak çekilir)
* Arama alanı sayesinde büyük listelerde filtreleme
* Tüm listelerde sayfalandırma (pagination) uygulanmıştır
* Her alan için dinamik olarak CRUD işlemleri gerçekleştirilebilir
* `wwwroot` dizini altındaki özel tasarımlı Admin şablonu üzerine kuruldu.

---

## 🔐 Login ve Register Paneli

CarBook projesinde kullanıcı kimlik doğrulama işlemleri, güvenliği ön planda tutacak şekilde yapılandırılmıştır. Kullanıcıların sisteme giriş ve kayıt işlemleri, JWT (JSON Web Token) teknolojisi ile desteklenerek oturum güvenliği sağlanmıştır.

### 🛡️ Güvenlik ve Rol Tabanlı Erişim

* Giriş yapan her kullanıcıya, rollerine göre özel token oluşturulmakta ve bu token üzerinden yetkilendirme yapılmaktadır.
* Uygulama içinde sadece yetkili kullanıcıların erişebileceği alanlar, rol tabanlı kontrol ile sınırlandırılmıştır.
* Örneğin, yalnızca Admin rolüne sahip kullanıcılar admin paneline erişebilirken; standart kullanıcılar yalnızca araç listeleme, kiralama ve blog okuma gibi kullanıcıya açık sayfalarda işlem yapabilir.
* Kullanıcılar rezervasyon işlemini tamamlayabilmesi için sisteme giriş yapması gerekmektedir.

---

## ✨  Proje Ekran Görüntüleri

---
## 🖥️ Kullanıcı Arayüzü
### Ana Sayfa
![DefaultIndex](https://github.com/user-attachments/assets/48d499a9-2187-4af7-86da-cb3a7348ea37)
### Araç Fiyatları
![CarPricingIndex](https://github.com/user-attachments/assets/8e252585-ffe5-4980-915b-acb2297ada73)
### Arabalar
![CarIndex](https://github.com/user-attachments/assets/268d86fe-9f35-47ed-989b-cc241421cf07)
### Araba Detay
![CarCarDetail1](https://github.com/user-attachments/assets/31897c58-dd13-4b8f-af6d-c87c31975a77)

![CarCarDetail2](https://github.com/user-attachments/assets/7785a1b2-26ed-4407-bb28-75996602dc53)
![CarCarDetail3](https://github.com/user-attachments/assets/95e0329a-2d25-4f37-9679-662640ecd541)
![CarReview](https://github.com/user-attachments/assets/7c887f32-a91d-4736-b3ab-904f4828c760)
### Bloglar
![BlogIndex](https://github.com/user-attachments/assets/5fa23b5b-ad7d-4870-a131-962633166f9c)
### Blog Detay
![BlogBlogDetail](https://github.com/user-attachments/assets/45481c31-9fc8-48a9-93eb-24b2885c0d05)
### İletişim
![ContactIndex](https://github.com/user-attachments/assets/5848e382-9026-4355-a158-6b376d2d2c38)
![ContactForm](https://github.com/user-attachments/assets/50691c83-7a8b-4f09-8d97-0b86ef6ffd79)
### Filtreli Araba Listesi
![RentACarList](https://github.com/user-attachments/assets/dd4a5845-4922-427f-b431-1f5605d69319)
### Rezervasyon
![ReservationIndex](https://github.com/user-attachments/assets/6e52bcd3-7e30-493f-9f65-deba533b54c5)
### Footer Alert
![Footer1](https://github.com/user-attachments/assets/5e1619f4-0b2b-4a71-a70d-ab1bc4459afb)
![Footer2](https://github.com/user-attachments/assets/4ba46a17-bdee-48c3-871c-0a63bb455e7f)
### Erişim Engelleyici
![AccessDenied](https://github.com/user-attachments/assets/15ac2aef-155a-4cc1-90e0-ddb978a6033f)
### Giriş & Kayıt
![LoginIndex](https://github.com/user-attachments/assets/48eab20a-70bf-4c43-98ff-c7b1ff94e3d8)
![RegisterCreateAppUser](https://github.com/user-attachments/assets/d732a5da-3141-4810-8ee8-f5edd7a9c33c)

---

## 🛠️ Admin Paneli
### Dashboard
![AdminDashboardIndex](https://github.com/user-attachments/assets/80d8cf77-cf3a-4250-9400-2666a85809b4)
### İstatistik
![AdminStatisticIndex](https://github.com/user-attachments/assets/e13b89cf-d849-4770-a870-c00a2ebb894a)
### Araba İşlemleri
![AdminCarIndex](https://github.com/user-attachments/assets/7aeafbdf-7642-4c05-82c5-e26a1305f6ce)
![AdminCarGetCarListByBrandId](https://github.com/user-attachments/assets/073fa28f-9e74-4cb7-81cc-2fc597a6ee6f)
### Araba Özellikleri
![AdminFeatureIndex](https://github.com/user-attachments/assets/1629fc49-5330-41ca-9da0-eb20ca04be35)
![AdminCarFeatureDetailIndex](https://github.com/user-attachments/assets/660a6b51-9452-4e11-bc4e-18b182d19003)
### Markalar
![AdminBrandIndex](https://github.com/user-attachments/assets/8a2e69db-8757-411a-8418-479ccbd1b4db)
### Banner Alanı
![AdminBannerIndex](https://github.com/user-attachments/assets/4a0c80a6-951a-4d11-8488-c864f5a22b03)
### Hakkımızda
![AdminAboutIndex](https://github.com/user-attachments/assets/87f8fe44-2b02-45e9-9aa3-74f9d861d8ff)
### Yazar İşlemleri
![AdminAuthorIndex](https://github.com/user-attachments/assets/2f9ce318-a07b-49af-a4d8-d893d6de3abb)
### Blog Kategorileri
![AdminCategoryIndex](https://github.com/user-attachments/assets/4265fd53-50da-4acc-8e6e-1621e1a16d05)
### Blog İşlemleri
![AdminBlogIndex](https://github.com/user-attachments/assets/65d9e43e-543a-4b27-8d2a-20ac814a74f4)
![AdminCommentIndex](https://github.com/user-attachments/assets/db6993d0-5cb5-473b-8c17-bc4ae485b8a8)
### Ödeme Türleri
![AdminPricingIndex](https://github.com/user-attachments/assets/f4199ebb-2fdd-4194-9e42-4e443822e2a7)
### İletişim
![AdminContactIndex](https://github.com/user-attachments/assets/63c7ea68-882c-4cdd-9f20-d345a34e1628)
### Alt Adres
![AdminFooterAddressIndex](https://github.com/user-attachments/assets/1c9cb0ef-f21e-4d5e-be48-230d789e49a3)
### Lokasyonlar
![AdminLocationIndex](https://github.com/user-attachments/assets/66eb48e4-bf52-40ee-ad90-28ea2715fee9)
### Hizmetler
![AdminServiceIndex](https://github.com/user-attachments/assets/b009090d-adef-456e-9fbc-4ff3d28e1c66)
### Sosyal Medya
![AdminSocialMediaIndex](https://github.com/user-attachments/assets/25f1be4c-3c35-4eea-bf6a-ba2219b736f5)
### Referanslar
![AdminTestimonialIndex](https://github.com/user-attachments/assets/bcee1158-c6e2-43f3-a524-42637c58a113)

## 🚀 API
![Swagger](https://github.com/user-attachments/assets/e27d177e-13dd-4745-949f-e5f766d5150d)

## ⚙ Veri Tabanı
![VeriTabanı](https://github.com/user-attachments/assets/49edb235-9fa7-4ed1-beac-7a2077564a0d)

























