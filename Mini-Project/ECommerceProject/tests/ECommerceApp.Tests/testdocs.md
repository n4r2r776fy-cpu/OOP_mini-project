Опис тестів у цьому проєкті

1) FinalTests.cs — юніт-тести для доменних сутностей і стратегій
- `Product_Price_ShouldBePositive`: перевіряє, що ціна продукту > 0.
- `Product_ReduceStock_Works`: зменшення кількості на складі працює (5 -> 3 при зменшенні на 2).
- `Order_InitialStatus_IsNew`: новостворений `Order` має статус `New`.
- `NoDiscount_DoesNothing`: `NoDiscountStrategy` повертає незмінну суму.
- `BulkDiscount_AppliesOver1000`: `BulkDiscountStrategy` застосовує знижку для сум > 1000 (перевірка на ~1000.01 → 900).
- `BulkDiscount_NoApplyUnder1000`: знижка не застосовується для сум менше порога.
- `Cannot_ReduceStock_BelowZero`: при спробі зменшити запас нижче нуля кидається `InvalidOperationException`.
- `Order_Cannot_BeEmpty_OnPay`: при спробі оплатити порожнє замовлення кидається `InvalidOperationException`.
- `Product_Name_CannotBeEmpty`: конструктор `Product` кидає `ArgumentException` при порожній назві.
- `TotalAmount_CalculatesCorrectly`: `Order.TotalAmount` правильно рахує суму елементів.
- `OrderItem_Quantity_MustBePositive`: конструктор `OrderItem` кидає `ArgumentException` при кількості 0.
- `Order_Status_Transition_Works`: після додавання позиції і виклику `MarkAsPaid()` статус стає `Paid`.

2) UnitTest1.cs — заглушка тесту
- `Test1`: порожній тест без асерцій, схоже заготовка або шаблон.

3) Integration/JsonProductRepositoryTests.cs — інтеграційні тести для `JsonProductRepository`
- `SaveAsync_CreatesFile_WhenRepositoryEmpty`: `SaveAsync` створює файл та записує `[]` коли репозиторій порожній.
- `Constructor_DoesNotThrow_WhenFileMissing`: конструктор не кидає виняток, якщо файлу немає.
- `LoadAsync_ReadsProductsFromFile`: `LoadAsync` читає продукти з JSON-файлу і повертає їх у репозиторій.
- `Constructor_Throws_OnCorruptedJson`: конструктор кидає виняток на пошкоджений JSON-файл.
- `SaveAsync_And_LoadAsync_Roundtrip`: перевірка кругового запису/зчитування (roundtrip) даних.
- `LoadAsync_OnNonexistentFile_DoesNotThrow`: `LoadAsync` на неіснуючому файлі не кидає і повертає порожній набір.
- `SaveAsync_WritesValidJson_Format`: при збереженні JSON містить очікувані поля (`Price`, `StockQuantity`).
- `LargeNumberOfProducts_Roundtrip_PerformanceSmoke`: простий перфоманс/строковий тест для великого списку (200) продуктів.

Примітка: прогін тестів на CI/локально показав `29` пройдених тестів, `0` провалених.

