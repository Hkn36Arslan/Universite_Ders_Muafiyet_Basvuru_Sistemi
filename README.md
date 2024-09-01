### Üniversite Ders Muafiyet Başvuru Sistemi

Bu proje, ASP.NET Core MVC, HTML, CSS ve JavaScript kullanılarak geliştirilmiş bir Üniversite Ders Muafiyet Başvuru Sistemi'dir. Sistem, öğrencilerin ders muafiyet başvurularını yapabileceği ve yöneticilerin bu başvuruları yönetebileceği iki ana panelden oluşmaktadır. 

## Proje Özeti

- **Teknolojiler**: ASP.NET Core MVC, HTML, CSS, JavaScript, MySQL
- **Paneller**: Öğrenci (Başvuranlar) Paneli, Yönetici Paneli
- **Veri Tabanı**: MySQL / Microsoft SQL Server Management Studio

## Özellikler

### Öğrenci (Başvuranlar) Paneli
1. **Kayıt ve Giriş:**
   - Öğrenciler, sisteme kayıt olduktan sonra giriş yapabilirler.
   
2. **Başvuru Formu:**
   - Öğrenciler, ders muafiyet başvuru formunu doldurur.
   - İstenen belgeler ve bilgiler girilir.
   - Form submit edildiğinde, başvuru bilgileri MySQL veri tabanına kaydedilir.
   - Öğrenci, doldurmuş olduğu başvuru formunun PDF formatında bir çıktısını alabilir ve bu dosya sunucuda saklanır.

### Yönetici Paneli
1. **Giriş:**
   - Yönetici, kendi paneline giriş yaparak başvuruları görüntüleyebilir.
   
2. **Başvuruları Görüntüleme:**
   - Yönetici, yapılan başvuruları ve yüklenen belgeleri inceleyebilir.
   - Başvurular, başvurulan bölüme göre filtrelenebilir.

3. **Yönetici Yetkilendirme:**
   - Sistemde iki tür yönetici bulunmaktadır: Süper Admin ve Bölüm Yöneticisi.
   - **Süper Admin**: 
     - Veri tabanında kayıtlı bilgileriyle sisteme giriş yapar ve diğer yöneticileri ekleme/silme yetkisine sahiptir.
     - Tüm bölümlere ait başvuruları görüntüleyebilir.
   - **Bölüm Yöneticisi**:
     - Sadece kendi bölümüne ait başvuruları görüntüleyebilir.

## Kurulum

1. **Veri Tabanı Kurulumu:**
   - Proje reposunda bulunan MuafiyetBasvuruSistemDB isimli dosyayı indirin ve aşağıda resimde gösterildiği gibi tercihen Microsoft SQL Server Management Studio kullanarak database dosyasını çalıştırın ve içeri aktarın.
     ![Ekran görüntüsü 2024-09-01 230621](https://github.com/user-attachments/assets/fb1b5848-ae16-425a-860e-5320a475becc) ![Ekran görüntüsü 2024-09-01 230657](https://github.com/user-attachments/assets/5c61b740-b282-4355-8d58-df5f5c09b975)
     Daha sonra Next diyip içeri aktarma işlemini tamamlayın. 
2. **Proje Ayarları:**
   - Gerekli dotnet kurulumlarını yaptıktan sonra tercihen VS Code ile projeyi clonlayın ve proje dosyalarına erişin : "https://github.com/Hkn36Arslan/Universite_Ders_Muafiyet_Basvuru_Sistemi.git"
   - VS Code ile projeyi açtıktan sonra New Terminal dedikten sonra proje dizinine gitmek için : cd Muafiyet_Basvuru_Sistemi_Projesi ile dizine gidin.
   - Sonra dizindeyken "dotnet run" komutunu vererek gelen localhost adresi ile projeyi ayağa kaldırın.
   - Proje çalıştığında gelen login-register sayfasında yönetici girii yapabilmek için " Email:admin@gmail.com , şifre:123 " bilgilerini girin. 
3. **Sunucu Ayarları:**
   - Bu proje Docker teknolojisi kullanılarak Erzurum Teknik Üniversitesi ağı üzerinde sunucu oluşturulup sürekli test edilerek tamamlanmıştır. Uzak sunucuya etü VPN ile bağlantı sağlanarak proje çalıştırılmaktadır.Bu noktada hata alınması durumunda lütfen projenizi yeni bir sunucu üzerine aktararak çalıştırınız.

## Kullanım

1. **Öğrenci Kaydı ve Başvuru:**
   - Öğrenci kayıt olur, giriş yapar ve başvuru formunu doldurur.
   - Form submit edildiğinde, öğrenci başvuru bilgilerini PDF olarak indirebilir.

2. **Yönetici Paneli:**
   - Yönetici, başvuruları görüntüleyebilir ve başvurulara ait belgeleri inceleyebilir.
   - Süper Admin, bölüm yöneticilerini ekleyebilir veya silebilir.
3. **Proje Demo Videosu:**
   [Hkn36Arslan_Universite_Ders_Muafiyet_Basvuru_Sistemi_ HTML,Css,JavaScript ile tasarlanmış .Net Core MVC tabanlı Üniversite Ders Muafiyet Başvuru Sistemi - Google Chrome 2024-09-01 23-50-32 (onlin.zip](https://github.com/user-attachments/files/16830547/Hkn36Arslan_Universite_Ders_Muafiyet_Basvuru_Sistemi_.HTML.Css.JavaScript.ile.tasarlanmis.Net.Core.MVC.tabanli.Universite.Ders.Muafiyet.Basvuru.Sistemi.-.Google.Chrome.2024-09-01.23-50-32.onlin.zip)

