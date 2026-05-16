# DEVELOPER GUIDE

Короткі вказівки для розробника

## Структура проєкту
- `src/ECommerceApp.Domain` — доменні сутності, стратегії, статуси.
- `src/ECommerceApp.Application` — бізнес-логіка, сервіси (OrderService).
- `src/ECommerceApp.Infrastructure` — persistence, `JsonProductRepository`.
- `src/ECommerceApp.Console` — точка входу для демонстрації.
- `tests/ECommerceApp.Tests` — юніт та інтеграційні тести.

## Налаштування середовища
- .NET SDK 6+ (перевірити `global.json` якщо є).
- Відновлення пакетів:

```powershell
dotnet restore
```

## Запуск тестів
```powershell
dotnet test tests/ECommerceApp.Tests/ECommerceApp.Tests.csproj
```

## Додавання нового use-case
1. Додати інтерфейс у `Application/Interfaces` за потреби.
2. Реалізувати сервіс у `Application/Services`.
3. Додати тести в `tests/ECommerceApp.Tests` (юніт + інтеграція при потребі).

## Стиль і рекомендації
- Маленькі класи, одне відповідальність на клас.
- Публічні API повинні мати XML-коментарі для кращої документації.

## Рефакторинг — приклади для FINAL_REPORT.md
- Видалення дублювання логіки підрахунків `TotalAmount` у кількох місцях.
- Винесення збереження/завантаження у окремий сервіс репозиторію.

