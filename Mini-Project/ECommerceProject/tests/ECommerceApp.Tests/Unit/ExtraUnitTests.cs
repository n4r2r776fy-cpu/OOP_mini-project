using System;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Strategies;
using Xunit;

namespace ECommerceApp.Tests.Unit
{
    public class ExtraUnitTests
    {
        [Fact]
        public void Product_Constructor_Throws_WhenPriceNotPositive() =>
            Assert.Throws<ArgumentException>(() => new Product("P", 0m, 1));

        [Fact]
        public void Product_Constructor_Throws_WhenStockNegative() =>
            Assert.Throws<ArgumentException>(() => new Product("P", 1m, -1));

        [Fact]
        public void Product_ReduceStock_InvalidQuantity_Throws() =>
            Assert.Throws<ArgumentException>(() => new Product("P", 1m, 5).ReduceStock(0));

        [Fact]
        public void Order_AddItem_NotAllowed_WhenNotNew()
        {
            var o = new Order("C");
            o.AddItem(new Product("A", 10m, 5), 1);
            o.MarkAsPaid();
            Assert.Throws<InvalidOperationException>(() => o.AddItem(new Product("B", 1m, 1), 1));
        }

        [Fact]
        public void Order_ApplyDiscount_InvalidPercentage_Throws() =>
            Assert.Throws<ArgumentException>(() => new Order("C").ApplyDiscount(-1m));

        [Fact]
        public void OrderItem_NullProduct_Throws() =>
            Assert.Throws<ArgumentNullException>(() => new OrderItem(null!, 1));

        [Fact]
        public void BulkDiscount_NoApply_OnExactly1000() =>
            Assert.Equal(1000m, new BulkDiscountStrategy().Apply(1000m));

        [Fact]
        public void Order_TotalAmount_WithDiscount_ComputesCorrectly()
        {
            var o = new Order("C");
            o.AddItem(new Product("A", 100m, 10), 2); // 200
            o.ApplyDiscount(10); // 10% of 200 = 20
            Assert.Equal(180m, o.TotalAmount);
        }
    }
}
