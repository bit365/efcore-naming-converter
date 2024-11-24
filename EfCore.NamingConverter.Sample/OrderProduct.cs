namespace EfCore.NamingConverter.Sample
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public required string ProductName { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = TimeProvider.System.GetUtcNow();
    }
}
