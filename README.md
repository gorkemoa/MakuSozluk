MakuSozluk Projesi
Bu proje, bir sözlük uygulamasının temel özelliklerini içeren bir ASP.NET Core MVC uygulamasıdır. Kullanıcılar başlıklar oluşturabilir, başlıklara içerik ekleyebilir ve başlıkları düzenleyebilir veya silebilirler. Ayrıca, başlıklar kategorilere ayrılarak organize edilir.

Proje Yapısı
Controllers: MVC kontrolleri burada bulunur.
DataAccessLayer: Veritabanı işlemleri için gerekli sınıflar burada bulunur.
EntityLayer: Veritabanı varlık sınıfları (models) burada bulunur.
BusinessLayer: İş mantığı işlemleri için gerekli sınıflar burada bulunur.
Views: MVC görünümleri (HTML dosyaları) burada bulunur.
wwwroot: Statik dosyalar (CSS, JavaScript, görüntüler) burada bulunur.
Kullanılan Teknolojiler
ASP.NET Core MVC
Entity Framework Core (Code First)
Bootstrap
JavaScript
Kurulum
Bu depoyu bilgisayarınıza klonlayın veya indirin.
Visual Studio veya Visual Studio Code gibi bir IDE kullanarak projeyi açın.
appsettings.json dosyasını açarak, veritabanı bağlantı dizesini kendi ortamınıza göre ayarlayın.
Package Manager Console'u kullanarak veritabanını oluşturmak için aşağıdaki komutu çalıştırın:
bash
Copy code
Update-Database
Projeyi başlatın ve uygulamayı tarayıcınızda görüntüleyin.
Katkıda Bulunma
Katkıda bulunmak istiyorsanız, önerilerinizi veya değişiklik taleplerinizi paylaşmaktan çekinmeyin.
Ana geliştirme dalına doğrudan katkıda bulunmak yerine, lütfen özellik/çözümleme dalı oluşturun ve onun üzerinde çalışın.
Lisans
Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına başvurun.

