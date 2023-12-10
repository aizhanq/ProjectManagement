using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string CustomerCompany { get; set; }

        [Required]
        public string ExecutorCompany { get; set; }

        public int ManagerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Range(1, 5, ErrorMessage = "Приоритет должен быть в диапазоне от 1 до 5")]
        public int Priority { get; set; }
    }
}
