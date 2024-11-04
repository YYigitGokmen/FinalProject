namespace MyApp.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }
        public User Customer { get; set; }

        // Many-to-many relationship with Products through OrderProduct
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
