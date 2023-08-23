using System.ComponentModel.DataAnnotations;

namespace DemoPetShop.Models
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }
        [Required]
        public string PageTitle { get; set; }
        [Required]
        public string PageBody { get; set; }
        [Required]
        public string? Published { get; set; }
        public string? PageImage { get; set; }
        public string? PageVideo { get; set; }
        public bool? Active { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
