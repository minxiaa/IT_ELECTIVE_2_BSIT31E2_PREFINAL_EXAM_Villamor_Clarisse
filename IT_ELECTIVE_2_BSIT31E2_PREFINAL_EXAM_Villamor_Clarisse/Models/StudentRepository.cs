

namespace IT_ELECTIVE_2_BSIT31E2_PREFINAL_EXAM_Villamor_Clarisse.Models
{
    public static class StudentRepository
    {
        public static List<Section> Sections { get; set; } = new()
        {
            new Section
            {
                SectionId = 1,
                SectionName = "BSIT-31E1"
            },
            new Section
            {
                SectionId = 2,
                SectionName = "BSIT-31E2"
            },
            new Section
            {
                SectionId = 3,
                SectionName = "BSIT-31E3"
            }
        };

        public static List<Student> Students { get; set; } = new()
        {
            new Student
            {
                StudentId = 1,
                StudentNumber = "1800-24",
                FirstName = "Alejandro",
                MiddleName = "Lorenzo",
                LastName = "Manzano",
                SectionId = 1
            },
            new Student
            {
                StudentId = 2,
                StudentNumber = "1699-24",
                FirstName = "Clarisse Anne",
                MiddleName = "Palacio",
                LastName = "Villamor",
                SectionId = 2
            }
        };
    }
}