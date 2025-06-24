namespace ResumeGenerator.Models
{
    public class Certificate
    {
        public int certificateId { get; set; }
        public string companyName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string specialization { get; set; }
        public double gpa { get; set; }


        public int resumeId { get; set; }
        public Resume resume { get; set; }

    }
}
