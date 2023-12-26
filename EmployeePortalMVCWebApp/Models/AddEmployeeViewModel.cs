using System.ComponentModel.DataAnnotations;
using static EmployeePortalMVCWebApp.Models.Employee;

namespace EmployeePortalMVCWebApp.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The Name field cannot exceed 20 characters.")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public string Designation { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number should be exactly 10 digits.")]
        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        [Required]
        public string Address { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Grade Grade { get; set; }
        [Required]
        public Country Country { get; set; }
        [Required]
        public City City { get; set; }

    }
}
