# BlogProje

ASP.NET Core MVC ile hazırlanmış katmanlı blog uygulaması. Uygulama .NET 8 hedefler, SQLite veritabanı kullanır ve ilk açılışta örnek kategori, yazar ve yazıları oluşturur.

## Katmanlar

- `Core`: Entity sınıfları, DTO'lar ve servis/depo arayüzleri
- `Business`: İş kuralları ve servisler
- `Data`: Entity Framework Core, SQLite ve depo uygulamaları
- `Web.UI`: MVC denetleyicileri, Razor görünümleri ve HTML/CSS arayüzü

## Çalıştırma

1. .NET 8 SDK'yı kur.
2. Visual Studio 2022'de `BlogProje.sln` çözümünü aç veya bu klasörde terminal aç.
3. Aşağıdaki komutu çalıştır:

```powershell
dotnet run --project Web.UI\Web.UI.csproj
```

Uygulama terminalde gösterilen yerel adreste açılır. SQLite dosyası `Web.UI/BlogProje.db` konumunda oluşur. EF Core paketleri `8.0.31` sürümündedir.

Proje GitHub'a gönderilmez; yerel çalışma içindir.
