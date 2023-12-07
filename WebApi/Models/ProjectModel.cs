namespace WebApi.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CustomerCompany { get; set; }
        public string ExecutorCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
    }
}
