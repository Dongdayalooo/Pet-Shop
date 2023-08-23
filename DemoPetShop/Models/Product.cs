using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoPetShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [StringLength(3000)]
        [Required]
        public string? ProductDescription { get; set; }
        [StringLength(500)]
        public string? ProductImage { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        [Required]
        public decimal? ProductPrice { get; set; }
        [Column(TypeName = "decimal(2,2)")]
        public decimal? ProductDiscount { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; }

        public bool? IsCat { get; set; }
        public bool? IsDog { get; set; }
        public bool? Active { get; set; }
    }
}
