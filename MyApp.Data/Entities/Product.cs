using System.ComponentModel.DataAnnotations;

namespace MyApp.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(100, ErrorMessage = "Product Name cannot be longer than 100 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock Quantity cannot be negative.")]
        public int StockQuantity { get; set; }

        // Many-to-many relationship with Orders through OrderProduct
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
