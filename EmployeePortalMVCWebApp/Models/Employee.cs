using System.ComponentModel.DataAnnotations;

namespace EmployeePortalMVCWebApp.Models
{

    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public enum Grade
    {
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }

    public enum Country
    {
        India,
        USA,
        UK
    }

    public enum City
    {
        Hyderabad,
        Bangalore,
        Mumbai,
        NewYork,
        Atlanta,
        London,
        Bristol
    }
    public class Employee
    {
       
        public Guid EmployeeId { get; set; }
        [StringLength(20, ErrorMessage = "The Name field cannot exceed 20 characters.")]
        [Required]
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
