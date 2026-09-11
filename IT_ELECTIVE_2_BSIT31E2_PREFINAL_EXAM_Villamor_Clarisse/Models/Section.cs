using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_BSIT31E2_PREFINAL_EXAM_Villamor_Clarisse.Models
{
    public class Section
    {
        public int SectionId { get; set; }

        [Required]
        public string SectionName { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
