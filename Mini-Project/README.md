#  E-Commerce Mini-Project: Iteration 3

Цей проєкт є навчальною моделлю системи управління складом інтернет-магазину. В ітерації №3 основний акцент зроблено на **Quality Gate**, автоматизованому тестуванні та стійкості системи до помилок (**Fault Handling**).

---

##  Технологічний стек
* **Мова:** C# 12 / .NET 10.0 (Preview)
* **Архітектура:** Clean Architecture (Domain, Application, Infrastructure, Console)
* **Тестування:** xUnit, Moq, Coverlet
* **Збереження даних:** JSON Persistence із Fault Tolerance

---

##  Основні фічі (Iteration 3)

### 1. Посилена тестова стратегія
* **Unit Tests:** Покрито критичну бізнес-логіку.
* **Integration Tests:** Перевірка циклу: "Створення -> Збереження -> Завантаження".
* **Negative Scenarios:** Тестування реакції на некоректні дані.

### 2. Fault Handling & Resilience
* Реалізовано перевірку цілісності даних при завантаженні.
* Додано доменні винятки для обробки специфічних помилок.

---

##  Показники якості (Quality Gate)
* **Загальна кількість тестів:** 28 (20 Unit + 8 Integration).
* **Code Coverage:** > 80%.

---

## 🔧 Як запустити
1. `dotnet build`
2. `dotnet test`

---
*Виконав: Гупалюк*