namespace ResumeGenerator.Models
{
    public class Resume : PersonalInfo
    {
        public int resumeId { get; set; }
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
        public List<Education> educations { get; set; } = new();
        public List<Experience> experiences { get; set; } = new();
        public List<Skill> skills { get; set; } = new();
        public List<Language> languages { get; set; } = new();
        public List<Certificate> certificates { get; set; } = new();
        public string endUserId { get; set; }
        public EndUser? endUser { get; set; }
        public bool isDeleted { get; set; }
    }
}
