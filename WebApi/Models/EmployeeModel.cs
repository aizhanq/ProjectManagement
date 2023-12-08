using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
