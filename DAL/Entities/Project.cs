using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CustomerCompany { get; set; }
        public string ExecutorCompany { get; set; }
        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Range(1, 5, ErrorMessage = "Приоритет должен быть в диапазоне от 1 до 5")]
        public int Priority { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
