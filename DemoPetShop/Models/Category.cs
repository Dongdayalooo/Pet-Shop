using System.ComponentModel.DataAnnotations;

namespace DemoPetShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public bool? Active { get; set; }


        //[ForeignKey("Brand")]
        //public int BrandId { get; set; }
        //public Brand? Brand { get; set; }
    }
}
