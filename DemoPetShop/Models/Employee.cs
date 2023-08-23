using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoPetShop.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [DisplayName(" Image Name")]
        public string EmployeeImage { get; set; }

        //[NotMapped]
        //[DisplayName("Upload File")]
        public IFormFile ImageFile;
    }
}
