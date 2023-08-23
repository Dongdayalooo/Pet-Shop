using System.ComponentModel.DataAnnotations;

namespace DemoPetShop.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string? BrandName { get; set; }
        public string? BrandImage { get; set; }
        public string? BrandDescription { get; set; }
        public bool? Active { get; set; }
    }
}
