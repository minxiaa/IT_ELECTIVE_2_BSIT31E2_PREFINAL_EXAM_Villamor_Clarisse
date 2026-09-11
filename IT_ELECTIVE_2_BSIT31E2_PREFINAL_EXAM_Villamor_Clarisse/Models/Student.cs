using System.ComponentModel.DataAnnotations;


namespace IT_ELECTIVE_2_BSIT31E2_PREFINAL_EXAM_Villamor_Clarisse.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string StudentNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int SectionId { get; set; }

        public Section? Section { get; set; }

        
    }
    
}
