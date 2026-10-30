using System.ComponentModel.DataAnnotations;

namespace Day3_DangHaiAnh.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100,MinimumLength =2, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }=string.Empty;
        //foreign key
        public int CategoryId { get; set; }
        // Navigation property
        public List<Product>? Products { get; set; }
    }
}
