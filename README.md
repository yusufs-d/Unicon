**Proje Sahibi:** Yusuf Salih Demir

**Proje İsmi:** Unicon

**Proje Hakkında:**

Unicon, üniversite öğrencilerine yönelik bir platformdur. Bu platformun odaklandığı sorun,
üniversite öğrencilerinin sosyalleşmesindeki zorluktur. Özellikle de yeni okula başlayan
öğrenciler, bu konuda epey zorlanabilmektedir. Unicon, bu soruna birçok özellikle birlikte
çözüm sunmaktadır. Bunlar:

1 - **Dersler bölümü:** Öğrenciler bu bölümde, daha önce hakkında bilgi sahibi olmadığı
dersler hakkında diğer öğrencilerin yorumları sayesinde bilgi alır. Eğer bilgisi varsa diğer
öğrenciler için yorum yapar. Ayrıca ilgili ders için ödev grubu arayan veya metaryel
ihtiyacı olanlar da bu bölümden faydalanabilir.

2 - **Hocalar Bölümü** : Bu bölümde öğrenciler, üniversite bulunan hocalar hakkında diğer
öğrenci yorumları ile bilgi sahibi olur. Kendileri de yorum yaparak diğer öğrencilere
yardımcı olabilirler.

3 - **Topluluk/Kulüpler Bölümü:** Bu bölüm, farklı ilgi alanlarına veya hobilere sahip
kullanıcıların bir araya gelebileceği sanal toplulukları veya kulüpleri içerir. Her bir
topluluk veya kulüp, ortak bir konu veya amaç etrafında bir araya gelmiş üyelerden
oluşur. Ayrıca bu bölümde kullanıcılar, ilgi alanlarına göre gruplar oluşturabilir, katılabilir
veya mevcut topluluklara erişebilir.

4 - **Buluşmalar Bölümü:** Bu bölüm, kullanıcıların gerçek dünyada buluşma
düzenleyebilecekleri veya katılabilecekleri etkinlikleri içerir. Kullanıcılar, belirli bir
konum veya tarih aralığına göre etkinlikleri arayabilir, katılabilir veya kendi etkinliklerini
oluşturabilirler. Bu bölüm, kullanıcıların sanal platformun ötesine geçerek sosyal
bağlantılar kurmalarına olanak tanır.

5 - **Değiş Tokuş Bölümü:** Bu bölüm, kullanıcıların eşyalarını veya hizmetlerini diğer
kullanıcılarla değiştirebilecekleri bir platform sağlar. Kullanıcılar, kullanmadıkları
eşyaları listeleyebilir, ihtiyaç duydukları şeyleri arayabilir ve diğer kullanıcılarla iletişime
geçerek değiş tokuş yapabilirler. Bu bölüm, kullanıcıların ekonomik ve çevresel olarak
sürdürülebilir bir yaşam tarzını teşvik eder.

6 - **Araç Arkadaşı Bölümü:** Bu bölüm, araç sahibi kullanıcıların üniversiteye gelirken yakıt
maliyetini paylaşmak ya da başka sebeplerden ötürü araçlarına arkadaş aramasını sağlar.
Okula toplu taşıma ile gelmek istemeyen kullanıcılar da bu kişileri bu bölümde rahatlıkla
bulabilir.

7 - **Kampüs Bölümü**: Bu bölüm, öğrencilere kampüs hakkında bilgiler verir ve öğrencilerin
kampüs ile alakalı yorumlar paylaşmasını sağlar.

8 - **Genel Sohbet Bölümü:** Bu bölüm, üniversite öğrencilerinin tamamının çeşitli konular
hakkında sohbet edebileceği veya birbirleriyle iletişim kurabileceği ortak bir alan sağlar.
Öğrenciler, genel konuları tartışabilir, sorular sorabilir, tavsiyeler alabilir ve diğer
öğrencilerle etkileşimde bulunabilirler. Bu bölüm, öğrencilerin tüm üniversite ile bağlantı
kurmalarını ve bilgi alışverişinde bulunmalarını sağlar.

9 - **Duyurular:** Bu bölüm, platformun yöneticileri tarafından kullanıcılara iletilmesi gereken
önemli duyuruları içerir. Kullanıcılar, üniversite ile alakalı önemli duyurulardan geri
kalmamış olur.

**Teknik Detaylar:**

**ASP.NET Core MVC** : Proje, ASP.NET Core MVC (Model-View-Controller) mimarisini temel
alır. Bu, sunucu tarafında çalışan bir web uygulaması geliştirmek için Microsoft tarafından
sunulan bir çerçevedir. MVC mimarisi, uygulamayı veri (model), kullanıcı arayüzü (view) ve iş
mantığı (controller) bileşenlerine ayırarak organize etmeye olanak tanır.

**Entity Framework Core:** Veritabanı işlemleri için Entity Framework Core kullanılmıştır. Bu,
.NET Core uygulamalarında veritabanı erişimini yönetmek için kullanılan bir ORM (Object-
Relational Mapping) çerçevesidir. Entity Framework Core, veritabanı işlemlerini kolaylaştırır ve
veritabanı tablolarını C# sınıflarıyla eşleştirir.

**Razor Pages:** Uygulamanın kullanıcı arayüzü Razor Pages kullanılarak geliştirilmiştir. Razor
Pages, ASP.NET Core ile sunulan bir web uygulaması modelleme yaklaşımıdır. Sayfa bazlı bir
yapıya sahiptir ve her bir Razor Page, sunulan içeriğin bir parçasını temsil eder.

**Bootstrap Framework:** Kullanıcı arayüzü, Bootstrap CSS framework'ü kullanılarak
oluşturulmuştur. Bootstrap, önceden tasarlanmış bileşenler ve stiller sağlayarak web
uygulamalarının hızlı bir şekilde geliştirilmesini sağlar. Ayrıca, duyarlı tasarımı destekleyerek
mobil cihazlarda da iyi bir görüntü sunar.

**JavaScript ve AJAX:** Bazı kullanıcı etkileşimleri ve dinamik içerikler için JavaScript ve AJAX
kullanılmıştır. Örneğin, kurs arama özelliği ve veri tabloları JavaScript ile gerçekleştirilmiştir.
Bu, kullanıcı deneyimini geliştirir ve sayfa yeniden yükleme gereksinimini azaltır.
**Entity Framework Identity:** Yetkilendirme, giriş, kayıt gibi kullanıcı işlemleri Efcore
modülünün sağlamış olduğu Identity sınıfı ile yapılmıştır. Bu sayede az kod kullanarak kullanıcı
tablolarının otomatik oluşturulması sağlanmıştır.
**Sonuç:**

Unicon projesi, modern web geliştirme tekniklerini kullanarak bir sosya platformu oluşturmayı
amaçlar. ASP.NET Core, C# ve diğer teknolojilerin bir araya getirilmesiyle geliştirilen bu proje,
kullanıcı dostu bir arayüz sunar ve veri güvenliğini sağlar. Proje, üniversite öğrencilerinin


ihtiyaçlarını karşılamak üzere tasarlanmıştır ve ilerleyen zamanlarda genişletilebilir ve
iyileştirilebilir bir yapıya sahiptir.


**Projeden Ekran Görüntüleri:**

![Screenshot 2024-03-27 at 00 55 55](https://github.com/yusufs-d/Unicon/assets/74401288/817370d7-a476-4f16-ad8c-94d05aed9f7c)

![Screenshot 2024-03-27 at 00 56 08](https://github.com/yusufs-d/Unicon/assets/74401288/d65c30ed-6739-4478-832f-465b6ed97a29)

![Screenshot 2024-03-27 at 00 54 31](https://github.com/yusufs-d/Unicon/assets/74401288/6a8fbfd6-74fe-41c5-bcf0-252139110016)

![Screenshot 2024-03-27 at 00 54 47](https://github.com/yusufs-d/Unicon/assets/74401288/93e30bcc-e292-413a-b6cd-e856f039e403)

![Screenshot 2024-03-27 at 00 55 07](https://github.com/yusufs-d/Unicon/assets/74401288/ffc17668-6517-47a7-a148-346a113eca63)

![Screenshot 2024-03-27 at 00 55 28](https://github.com/yusufs-d/Unicon/assets/74401288/93d1db0c-f4cc-4e52-ad63-c2f64e2cd095)

![Screenshot 2024-03-27 at 00 55 44](https://github.com/yusufs-d/Unicon/assets/74401288/d9e213fa-725d-44ab-8816-29cd8ae0cfcd)












