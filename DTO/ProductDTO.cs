using System.ComponentModel.DataAnnotations;

namespace storeManagerDotNet.DTO
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "\"name\" is required")]
        [MinLength(5, ErrorMessage = "\"name\" length must be at least 5 characters long")]
        public string? Name { get; set; }
    }
}
