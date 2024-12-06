# MatchChat - Türkiye Süper Ligi Canlı Maç Sohbet Platformu

---

## İçindekiler
1. [Proje Hakkında](#proje-hakkında)
2. [Teknolojiler](#teknolojiler)
3. [Proje Yapısı](#proje-yapısı)
4. [Özellikler](#özellikler)
5. [Kurulum](#kurulum)
6. [Test](#test)
7. [Yapılan İşler](#yapılan-işler)
8. [Yapılacak İşler](#yapılacak-işler)

---

## Proje Hakkında

MatchChat, Türkiye Süper Ligi'ndeki canlı maçlar için gerçek zamanlı sohbet odaları sunan bir web uygulamasıdır. Kullanıcılar aktif maçlara katılarak diğer taraftarlarla etkileşime girebilir. Her maç için ayrı bir sohbet odası oluşturulur ve yalnızca aktif maçların sohbet odalarına erişilebilir.

### Temel Özellikler
- Kullanıcı kaydı ve girişi
- Canlı maçları görüntüleme
- Gerçek zamanlı sohbet
- Canlı skor güncellemeleri
- Kullanıcı seviye sistemi

---

## Teknolojiler

### Backend
- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (Docker container)
- SignalR (gerçek zamanlı iletişim)
- JWT Authentication
- Football-API (Maç verileri için)

### Frontend
- React 18
- TypeScript
- React Router v6
- Tailwind CSS
- Axios
- SignalR Client

### Test
- Jest & React Testing Library (Frontend unit testler)
- Cypress (E2E testler)
- xUnit (Backend unit testler)

### Diğer Araçlar
- Docker
- Git
- Visual Studio 2022
- Visual Studio Code

---

## Proje Yapısı

### Backend Solution Yapısı
MatchChat/
├── src/
│   ├── MatchChat.API/           # API Controllers ve startup yapılandırması
│   ├── MatchChat.Core/          # Domain entities ve interfaces
│   ├── MatchChat.Infrastructure/ # External servislerin implementasyonları
│   └── MatchChat.Application/   # Business logic ve servisler
└── tests/
    ├── MatchChat.UnitTests/     # Unit testler
    └── MatchChat.IntegrationTests/ # Integration testler


### Frontend Proje Yapısı
matchchat.web/
├── public/                      # Statik dosyalar (favicon, index.html vs.)
├── src/
│   ├── components/              # Yeniden kullanılabilir UI bileşenleri
│   │   ├── Layout.tsx
│   │   ├── MatchScore.tsx
│   │   ├── MatchChat.tsx
│   │   └── ProtectedRoute.tsx
│   ├── pages/                   # Sayfa bileşenleri
│   │   ├── Login.tsx
│   │   ├── Register.tsx
│   │   ├── MatchList.tsx
│   │   └── MatchDetail.tsx
│   ├── services/                # API ve SignalR servisleri
│   │   ├── authService.ts
│   │   └── signalRService.ts
│   ├── types/                   # TypeScript tip tanımlamaları
│   │   ├── auth.ts
│   │   └── match.ts
│   └── test-utils/              # Test yardımcı fonksiyonları



---

## Özellikler

### Kullanıcı İşlemleri
- Kayıt olma (email doğrulama)
- Giriş yapma
- Profil yönetimi
- Favori takım seçimi

### Maç İşlemleri
- Canlı maçları görüntüleme
- Gelecek maçları görüntüleme
- Canlı skor takibi
- Maç istatistikleri

### Sohbet Özellikleri
- Gerçek zamanlı mesajlaşma
- Mesaj alıntılama
- Emoji desteği
- 5 saniyelik spam koruması
- Kullanıcı seviyeleri

---

## Kurulum

### Gereksinimler
- .NET 8.0 SDK
- Node.js ve npm
- Docker Desktop
- PostgreSQL
- Visual Studio 2022 veya VS Code

### Backend Kurulum
```bash
# Repository'yi klonlayın
git clone https://github.com/yourusername/matchchat.git

# PostgreSQL'i Docker ile başlatın
docker-compose up -d

# Migration'ları çalıştırın
dotnet ef database update


### Frontend Kurulum

# Frontend klasörüne gidin
cd matchchat.web

# Bağımlılıkları yükleyin
npm install

# Geliştirme sunucusunu başlatın
npm start


### Test

## Backend Testleri

# Tüm testleri çalıştırma
dotnet test

# Belirli bir test projesini çalıştırma
dotnet test MatchChat.UnitTests

## Frontend Testleri

# Unit testleri çalıştırma
npm test

# Test coverage raporu
npm test -- --coverage

# Cypress E2E testlerini çalıştırma
npm run cypress:open


Yapılan İşler

Proje Başlangıcı ve Temel Yapı
- Solution yapısı oluşturuldu
- Temel klasör yapısı hazırlandı
- Docker compose dosyası hazırlandı

Backend Geliştirmeleri
- Entity modelleri oluşturuldu
- PostgreSQL entegrasyonu tamamlandı
- Repository pattern implementasyonu

Frontend Geliştirmeleri
- React projesi oluşturuldu
- Routing yapısı kuruldu
- Temel componentler oluşturuldu

Test Altyapısı
- Jest ve React Testing Library kurulumu
- İlk test senaryoları yazıldı
- Test utilities oluşturuldu

Yapılacak İşler

Backend Görevleri
- SignalR Hub Geliştirmesi
  - Canlı sohbet altyapısının kurulması
  - Mesaj geçmişi yönetimi
  - Kullanıcı bağlantı yönetimi
- Football-API Entegrasyonu
  - API servisinin oluşturulması
  - Veri çekme ve dönüştürme işlemleri
  - Cache mekanizması
- Kullanıcı Sistemi
  - Email doğrulama sistemi
  - Şifre sıfırlama
  - Profil yönetimi
- Güvenlik
  - Rate limiting implementasyonu
  - Input validasyonları
  - XSS koruması

Frontend Görevleri
- UI/UX Geliştirmeleri
  - Responsive tasarım
  - Tema sistemi
  - Loading states
- Sohbet Özellikleri
  - Emoji picker
  - Mesaj alıntılama UI
  - Otomatik scroll
- Maç Sayfası
  - Canlı skor gösterimi
  - İstatistik grafikleri
  - Olay akışı
- Form Validasyonları
  - Login formu
  - Register formu
  - Profil güncelleme formu

Test Görevleri
- Backend Tests
  - Unit testlerin tamamlanması
  - Integration testlerin yazılması
  - Performance testleri
- Frontend Tests
  - Component testleri
  - E2E senaryoları
  - Mock service testleri

DevOps Görevleri
- CI/CD Pipeline
  - GitHub Actions kurulumu
  - Otomatik deployment
  - Test automation
- Monitoring
  - Log sistemi
  - Error tracking
  - Performance monitoring

Dokümantasyon
- API Dokümantasyonu
  - Swagger/OpenAPI
  - Endpoint açıklamaları
  - Request/Response örnekleri
- Kullanıcı Dokümantasyonu
  - Kullanım kılavuzu
  - SSS
  - Video tutoriallar

Öncelikli Görevler
- Authentication sisteminin tamamlanması
- Football-API entegrasyonu
- SignalR chat sistemi
- Temel UI componentlerinin tamamlanması
- Test coverage'ının artırılması

Notlar
- Tüm geliştirmeler feature branch'lerde yapılacak
- Kod kalitesi için Sonar analizi kullanılacak
- Her sprint sonunda security audit yapılacak
- Performance monitoring için Azure Application Insights kullanılacak

