using System.ComponentModel.DataAnnotations;

namespace storeManagerDotNet.DTO
{
    public class ProductDTO
    {
        [Required]
        [MinLength(5)]
        public string? Name { get; set; }
    }
}
