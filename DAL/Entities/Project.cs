namespace DAL.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CustomerCompany { get; set; }
        public string ExecutorCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }

        // Навигационное свойство для связи с сотрудниками проекта
        public virtual ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
