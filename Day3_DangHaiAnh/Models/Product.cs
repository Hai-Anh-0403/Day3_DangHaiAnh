namespace Day3_DangHaiAnh.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; } =String.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = String.Empty;
        // Foreign key
        public int CategoryId { get; set; }
        // Navigation property
        public Category? Category { get; set; }
    }
}
