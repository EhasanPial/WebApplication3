using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can't exceeds 50 character")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        public Dept Department { get; set; }
    }
}
