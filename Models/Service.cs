namespace ResumeGenerator.Models
{
    public class Service
    {
        public int serviceId { get; set; }
        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public string serviceImage { get; set; }

        public List<Project> projects { get; set; } = new();


    }
}
