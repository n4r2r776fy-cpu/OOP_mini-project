namespace ECommerceApp.Domain.Strategies
{
    public class BulkDiscountStrategy : IDiscountStrategy
    {
        public decimal Apply(decimal total)
        {
            if (total <= 1000) return total;
            var discounted = total * 0.9m;
            return decimal.Round(discounted, 0);
        }
    }
}