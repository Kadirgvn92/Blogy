# Blogy Blog Web Sitesi

## ASP.NET 6 MVC

Bu proje, .NET 6 kullanarak geliştirilmiş bir blog web sitesidir. Proje, aşağıdaki teknolojileri ve mimarileri kullanmaktadır:

### Teknolojiler

- **ASP.NET 6:** Web uygulamaları geliştirmek için kullanılan bir framework.
- **MVC (Model-View-Controller):** Projede kullanılan mimari yapısı. Model, View ve Controller bileşenlerini içerir.
- **Entity Framework Core:** Veritabanı işlemlerini yönetmek için kullanılan bir ORM aracı.
- **Bootstrap 5:** Modern ve duyarlı bir kullanıcı arayüzü tasarımı için kullanılan bir CSS framework'ü.
- **Fluent Validation:** Veri doğrulamasını gerçekleştirmek için kullanılan bir kütüphane.
- **N Katmanlı Mimari (Repository Design Pattern):** Projeyi katmanlara ayırarak modüler bir yapı oluşturur.

### Proje Detayları

1. **MVC Mimarisi:** Proje, MVC mimarisini kullanarak kodu modüler hale getirir. Bu sayede model, view ve controller bileşenleri ayrı tutularak geliştirme süreci daha organize hale gelir.

2. **N Katmanlı Mimari:** Proje, N katmanlı mimari yaklaşımını benimser. Bu sayede projeyi katmanlara ayırarak bakımını kolaylaştırır ve genişletilebilir bir yapı oluşturur. Repository design pattern kullanılarak veritabanı işlemleri ayrı bir katmanda yönetilir.

3. **Bootstrap ile Kullanıcı Arayüzü Tasarımı:** Projede Bootstrap 5 kullanılarak modern ve duyarlı bir kullanıcı arayüzü tasarımı oluşturulur. Bu sayede uygulama farklı cihazlarda ve ekran boyutlarında uyumlu hale gelir.

4. **Fluent Validation ile Veri Doğrulama:** Kullanıcı girişlerinin doğrulanması için Fluent Validation kütüphanesi kullanılır. Bu sayede gelen verilerin doğruluğu sağlanır ve güvenlik artırılır.

### Proje İçeriği

Bu proje, bir blog web sitesinin temel işlevselliğini sağlar. Ana bölümler aşağıdaki gibidir:

1. **Blog Makaleleri Yönetimi 📝**
   - Makale Oluşturma: Yazarlar tarafından yeni makalelerin oluşturulması.
   - Makale Düzenleme: Var olan makalelerin düzenlenmesi ve güncellenmesi.
   - Makale Silme: İstenmeyen makalelerin silinmesi.
   - Kategori Yönetimi: Makalelerin kategorize edilmesi için kategori yönetimi.
   - Yorum Yönetimi: Makalelere yapılan yorumların yönetimi, onaylama ve silme işlemleri.

2. **Kullanıcı Yönetimi 👤**
   - Kullanıcı Kaydı: Yeni kullanıcıların kaydının yapılması.
   - Kullanıcı Girişi: Kayıtlı kullanıcıların sisteme giriş yapması.
   - Profil Düzenleme: Kullanıcıların profil bilgilerini düzenlemesi.

3. **Arama ve Filtreleme 🔍**
   - Makale Arama: Makaleler arasında anahtar kelime veya kategoriye göre arama yapma.
   - Kategoriye Göre Filtreleme: Belirli bir kategoriye ait makaleleri filtreleme.

4. **Yetkilendirme ve Kimlik Doğrulama 🔒**
   - Kullanıcıların sadece yetkilerine uygun işlemleri yapabilmesi için yetkilendirme.
   - Kullanıcıların kimlik doğrulaması ile güvenli giriş yapması.

### Kurulum

1. **Gerekli Araçlar ve Ortam:**
   - .NET 6 SDK ve Visual Studio gibi geliştirme ortamlarının kurulması.
   - SQL Server veritabanının kurulması veya uzak bir SQL Server bağlantısının sağlanması.

2. **Projenin İndirilmesi ve Çalıştırılması:**
   - Projenin GitHub deposundan veya ZIP olarak indirilmesi.
   - Visual Studio'da projenin açılması.
   - Veritabanının oluşturulması ve gerekli bağlantı ayarlarının yapılması.
   - Projeyi çalıştırarak web sunucusunda uygulamanın çalıştırılması.

### Ekran Görüntüleri

Aşağıda, projenin bazı ekran görüntüleri bulunmaktadır:

![Ekran Görüntüsü 1](/path/to/screenshot1.png)
![Ekran Görüntüsü 2](/path/to/screenshot2.png)
![Ekran Görüntüsü 3](/path/to/screenshot3.png)
![Ekran Görüntüsü 4](/path/to/screenshot4.png)

---

Bu README dosyası, projenin nasıl geliştirildiğini, hangi teknolojilerin kullanıldığını ve projenin temel işlevselliğini açıklamak için hazırlanmıştır. Ayrıca, projenin kurulumu ve çalıştırılması için gerekli adımlar da belirtilmiştir.
