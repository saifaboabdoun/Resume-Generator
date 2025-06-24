namespace ResumeGenerator.Models
{
    public class Experience
    {
        public int experienceId { get; set; }
        public String title { get; set; }
        public String companyName { get; set; }
        public String startDate { get; set; }
        public String endDate { get; set; }
        public bool isCurrent { get; set; }
        public String description { get; set; }

        public int resumeId { get; set; }
        public Resume resume { get; set; }


    }
}
