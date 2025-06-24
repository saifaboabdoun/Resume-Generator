namespace ResumeGenerator.Models
{
    public class Skill
    {
        public int skillId { get; set; }
        public string skillName { get; set; }
        public string skillType { get; set; }

        public int resumeId { get; set; }
        public Resume resume { get; set; }


    }
}
