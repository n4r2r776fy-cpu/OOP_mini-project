# Test Matrix

Use case -> Tests mapping

- Order creation & payment
  - Unit: Order_Status_Transition_Works, Order_Cannot_BeEmpty_OnPay
  - Integration: (covered via service tests if persisted orders were available)

- Product inventory
  - Unit: Product_Price_ShouldBePositive, Product_ReduceStock_Works, Cannot_ReduceStock_BelowZero
  - Integration: JsonProductRepository roundtrip tests

- Discount strategies
  - Unit: NoDiscount_DoesNothing, BulkDiscount_AppliesOver1000, BulkDiscount_NoApplyUnder1000, BulkDiscount_NoApply_OnExactly1000

- Persistence
  - Integration: SaveAsync_CreatesFile_WhenRepositoryEmpty, LoadAsync_ReadsProductsFromFile, SaveAsync_And_LoadAsync_Roundtrip, Constructor_Throws_OnCorruptedJson

