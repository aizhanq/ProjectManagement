namespace DAL.Entities
{
    public class EmployeeProject
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }       
    }
}
