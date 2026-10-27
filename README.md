# ManagmentSsytem

Система для управління [Users, Items, Actions] з MVC-адмін-панеллю та MAUI-застосунком.

## Вимоги

- Visual Studio 2022 Community
- .NET 8 SDK
- Робочі навантаження: ASP.NET and web development, .NET MAUI
- Android емулятор (API 33)

## Встановлення

1. Клонувати репозиторій:
   `git clone <посилання>`
2. Відкрити файл рішення (`.slnx`) у Visual Studio 2026.
3. Дочекатися відновлення NuGet-пакетів.
4. Для запуску сервера: обрати `ServerApp` як стартовий проєкт і натиснути F5.
5. Для запуску клієнта: обрати `ClientApp` як стартовий проєкт, вибрати Android емулятор і натиснути F5.

## Структура проєкту

- `Server/ServerApp` - ASP.NET Core проєкт (.NET 10, HTTPS)
- `Client/ClientApp` - .NET MAUI застосунок (.NET 10)
- `Client/ClientApp/ViewModels` - ViewModels для шаблону MVVM