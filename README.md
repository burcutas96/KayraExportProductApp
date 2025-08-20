# Product API

Bu proje, ürün yönetimi için geliştirilmiş bir **.NET Core Web API**
uygulamasıdır.\
Swagger dokümantasyonu ile RESTful ilkelerine ve Katmanlı Mimari prensiplerine uygun şekilde tasarlanmıştır.

<br>

##  Özellikler

-    Ürün CRUD işlemleri
-    Katmanlı mimari 
-    Asenkron programlama
-    Entity Framework Core ile veritabanı işlemleri
-    Standart response modeli
-    Exception handling 
-    Swagger/OpenAPI dokümantasyonu

<br>

## Kullanılan Teknolojiler

-   .NET 6+
-   Entity Framework Core
-   Swagger / Swashbuckle

<br>

##  Kurulum

### 1. Projeyi Klonlayın

```bash
git clone <repository-url>
```

<br>

### 2. Proje Dizine Gidin ve Açın
Projeyi açmanın iki yolu vardır:

a) Terminal üzerinden Visual Studio ile açmak:

```bash
cd KayraExportProductApp/Backend/ProductAPI

start ProductAPI.sln
```
Bu komut Visual Studio’yu açar ve çözüm dosyasını yükler.

b) Manuel olarak açmak:
- Windows Gezgini ile KayraExportProductApp/Backend/ProductAPI klasörüne gidin.

- ProductAPI.sln dosyasına çift tıklayarak Visual Studio’da açın.

<br>

### 3. Startup Projesini Ayarlayın
Visual Studio’da birden fazla proje varsa, **hangi projenin çalıştırılacağını** belirtmek önemlidir.

1. Solution Explorer’da `API` projesine sağ tıklayın. 
2. Açılan menüden **Set as Startup Project** seçeneğini seçin. 
3. Artık projeyi çalıştırdığınızda doğru proje (API) başlatılacaktır.

<br>

### 4. Veritabanı Bağlantısını Ayarlayın
`appsettings.json` dosyasındaki connection string'i güncelleyin:

```json
{
  "ConnectionStrings": {
    "SqlConnection": "Server=YOUR_SERVER;Database=ProductDB;TrustServerCertificate=true;Integrated Security=true;"
  }
}
```

<br>

### 5. Veritabanını Oluşturun

Migration dosyaları proje içinde yer almaktadır.  
Bu nedenle yalnızca aşağıdaki komutla veritabanını güncellemeniz yeterlidir:

```bash
# Package Manager Console (Visual Studio)
Update-Database


# Veya CLI
dotnet ef database update
```

<br>

### 6. Bağımlılıkları Yükleyin

```bash
dotnet restore
```

<br>


### 7. API'yi Çalıştırma

```bash
# Visual Studio'da:
Ctrl + F5

# CLI üzerinden:
dotnet run
```

<br>

##  Swagger Dokümantasyonu

Projeyi çalıştırdıktan sonra Swagger arayüzüne erişmek için:

👉 <https://localhost:7092/swagger/index.html>

Swagger üzerinden tüm endpointleri test edebilir, response tiplerini
görebilirsiniz.


