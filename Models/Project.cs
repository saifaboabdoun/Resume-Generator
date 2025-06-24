namespace ResumeGenerator.Models
{
    public class Project
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public int serviceId { get; set; }
        public Service service { get; set; }

        public string githubLink { get; set; }
    }
}
