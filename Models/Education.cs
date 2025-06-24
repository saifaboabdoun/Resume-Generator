using System.ComponentModel.DataAnnotations;

namespace ResumeGenerator.Models
{
    public class Education
    {
        public int educationId { get; set; }

        [Required]
        public string collageName { get; set; }

        [Required]
        public string degreeType { get; set; }

        [Required]
        public string startDate { get; set; }

        [Required]
        public string endDate { get; set; }

        [Required]
        public string major { get; set; }

        [Required]
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public double gpa { get; set; }

        [Required]
        public int resumeId { get; set; }
        public Resume resume { get; set; }
    }
}
