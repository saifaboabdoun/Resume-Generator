namespace ResumeGenerator.Models
{
    public class Language
    {

        public int languageId { get; set; }
        public string languageName { get; set; }
        public int languageLevel { get; set; }

        public int resumeId { get; set; }
        public Resume resume { get; set; }

    }

}
