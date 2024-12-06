# MatchChat - Türkiye Süper Ligi Canlı Maç Sohbet Platformu

MatchChat, Türkiye Süper Ligi'ndeki canlı maçlar için gerçek zamanlı sohbet odaları sunan bir web uygulamasıdır. Kullanıcılar aktif maçlara katılarak diğer taraftarlarla etkileşime girebilir.

## 📑 İçindekiler

- [Proje Hakkında](#proje-hakkında)
- [Teknolojiler](#teknolojiler)
- [Proje Yapısı](#proje-yapısı)
- [Özellikler](#özellikler)
- [Kurulum](#kurulum)
- [Test](#test)
- [Yapılan İşler](#yapılan-işler)
- [Yapılacak İşler](#yapılacak-işler)

## 🎯 Proje Hakkında

Her maç için ayrı bir sohbet odası oluşturulur ve yalnızca aktif maçların sohbet odalarına erişilebilir.

### Temel Özellikler

- 👤 Kullanıcı kaydı ve girişi
- 🎮 Canlı maçları görüntüleme
- 💬 Gerçek zamanlı sohbet
- 🎯 Canlı skor güncellemeleri
- ⭐ Kullanıcı seviye sistemi

## 🛠 Teknolojiler

### Backend
- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (Docker container)
- SignalR
- JWT Authentication
- Football-API

### Frontend
- React 18
- TypeScript
- React Router v6
- Tailwind CSS
- Axios
- SignalR Client

### Test
- Jest & React Testing Library
- Cypress
- xUnit

### DevOps & Araçlar
- Docker
- Git
- Visual Studio 2022
- Visual Studio Code

## 📁 Proje Yapısı

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


## ✨ Özellikler

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
- Spam koruması
- Kullanıcı seviyeleri

## 🚀 Kurulum

### Gereksinimler
- .NET 8.0 SDK
- Node.js ve npm
- Docker Desktop
- PostgreSQL
- Visual Studio 2022 veya VS Code

### Backend Kurulum

\`\`\`bash
# Repository'yi klonlayın
git clone https://github.com/yourusername/matchchat.git

# PostgreSQL'i Docker ile başlatın
docker-compose up -d

# Migration'ları çalıştırın
dotnet ef database update
\`\`\`

### Frontend Kurulum

\`\`\`bash
# Frontend klasörüne gidin
cd matchchat.web

# Bağımlılıkları yükleyin
npm install

# Geliştirme sunucusunu başlatın
npm start
\`\`\`

## 🧪 Test

### Backend Testleri

\`\`\`bash
# Tüm testleri çalıştırma
dotnet test

# Belirli bir test projesini çalıştırma
dotnet test MatchChat.UnitTests
\`\`\`

### Frontend Testleri

\`\`\`bash
# Unit testleri çalıştırma
npm test

# Test coverage raporu
npm test -- --coverage

# E2E testleri
npm run cypress:open
\`\`\`

## ✅ Yapılan İşler

### Proje Başlangıcı
- ✅ Solution yapısı oluşturuldu
- ✅ Temel klasör yapısı hazırlandı
- ✅ Docker compose dosyası hazırlandı

### Backend
- ✅ Entity modelleri oluşturuldu
- ✅ PostgreSQL entegrasyonu
- ✅ Repository pattern implementasyonu

### Frontend
- ✅ React projesi oluşturuldu
- ✅ Routing yapısı kuruldu
- ✅ Temel componentler oluşturuldu

### Test
- ✅ Jest ve RTL kurulumu
- ✅ İlk test senaryoları
- ✅ Test utilities

## 📋 Yapılacak İşler

### Backend Görevleri
- [ ] SignalR Hub Geliştirmesi
  - Canlı sohbet altyapısı
  - Mesaj geçmişi yönetimi
  - Kullanıcı bağlantı yönetimi
- [ ] Football-API Entegrasyonu
- [ ] Kullanıcı Sistemi
- [ ] Güvenlik İyileştirmeleri

### Frontend Görevleri
- [ ] UI/UX Geliştirmeleri
- [ ] Sohbet Özellikleri
- [ ] Maç Sayfası
- [ ] Form Validasyonları

### Test Görevleri
- [ ] Backend Tests
- [ ] Frontend Tests
- [ ] E2E Tests

### DevOps Görevleri
- [ ] CI/CD Pipeline
- [ ] Monitoring
- [ ] Log Sistemi

### Dokümantasyon
- [ ] API Dokümantasyonu
- [ ] Kullanıcı Kılavuzu
- [ ] Geliştirici Dokümantasyonu

## 📌 Notlar

- Tüm geliştirmeler feature branch'lerde yapılacak
- Kod kalitesi için Sonar analizi kullanılacak
- Her sprint sonunda security audit yapılacak
- Performance monitoring için Azure Application Insights kullanılacak

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için [LICENSE](LICENSE) dosyasına bakınız.