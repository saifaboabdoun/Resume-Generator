namespace ResumeGenerator.Models
{
    public class Portfolio:PersonalInfo
    {

        public int portfolioId { get; set; }
        public string personalImage { get; set; }
        public List<Service> services { get; set; } = new();
        public List<Project> projects { get; set; } = new();
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
        public bool isDeleted { get; set; }

    }
}
