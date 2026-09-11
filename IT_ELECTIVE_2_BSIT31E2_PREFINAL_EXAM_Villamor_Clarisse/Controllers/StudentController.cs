using Microsoft.AspNetCore.Mvc;
using IT_ELECTIVE_2_BSIT31E2_PREFINAL_EXAM_Villamor_Clarisse.Models;

namespace IT_ELECTIVE_2_BSIT31E2_PREFINAL_EXAM_Villamor_Clarisse.Controllers
{
    public class StudentController : Controller
    {
       

        public IActionResult Index()
        {
            var students = StudentRepository.Students;

          
            foreach (var student in students)
            {
                student.Section = StudentRepository.Sections
                    .FirstOrDefault(s => s.SectionId == student.SectionId);
            }

            return View(students);
        }


       

        public IActionResult Details(int id)
        {
            var student = StudentRepository.Students
                .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            student.Section = StudentRepository.Sections
                .FirstOrDefault(s => s.SectionId == student.SectionId);

            return View(student);
        }


       

        [HttpGet]
        public IActionResult Create()
        {
            var model = new StudentViewModel
            {
                Sections = StudentRepository.Sections
            };

            return View(model);
        }


      

        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            try
            {
               
                if (!ModelState.IsValid)
                {
                    model.Sections = StudentRepository.Sections;
                    return View(model);
                }

               
                var duplicate = StudentRepository.Students
                    .Any(s => s.StudentNumber == model.StudentNumber);

                if (duplicate)
                {
                    ModelState.AddModelError(
                        "StudentNumber",
                        "Student Number already exists."
                    );

                    model.Sections = StudentRepository.Sections;

                    return View(model);
                }

                
                int newId = StudentRepository.Students.Count == 0
                    ? 1
                    : StudentRepository.Students.Max(s => s.StudentId) + 1;


                var student = new Student
                {
                    StudentId = newId,
                    StudentNumber = model.StudentNumber,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                  
                    SectionId = model.SectionId
                };


                StudentRepository.Students.Add(student);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = StudentRepository.Students
                .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            var model = new StudentViewModel
            {
                StudentId = student.StudentId,
                StudentNumber = student.StudentNumber,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                
                SectionId = student.SectionId,
                Sections = StudentRepository.Sections
            };

            return View(model);
        }




        [HttpPost]
        public IActionResult Edit(StudentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var error in ModelState)
                    {
                        foreach (var message in error.Value.Errors)
                        {
                            Console.WriteLine($"{error.Key}: {message.ErrorMessage}");
                        }
                    }

                    model.Sections = StudentRepository.Sections;
                    return View(model);
                }

                var student = StudentRepository.Students
                    .FirstOrDefault(s => s.StudentId == model.StudentId);

                if (student == null)
                {
                    return NotFound();
                }

                
                var duplicate = StudentRepository.Students
                    .Any(s =>
                        s.StudentNumber == model.StudentNumber &&
                        s.StudentId != model.StudentId);

                if (duplicate)
                {
                    ModelState.AddModelError(
                        "StudentNumber",
                        "Student Number already exists."
                    );

                    model.Sections = StudentRepository.Sections;

                    return View(model);
                }

                student.StudentNumber = model.StudentNumber;
                student.FirstName = model.FirstName;
                student.MiddleName = model.MiddleName;
                student.LastName = model.LastName;
              
                student.SectionId = model.SectionId;

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = StudentRepository.Students
                .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            student.Section = StudentRepository.Sections
                .FirstOrDefault(s => s.SectionId == student.SectionId);

            return View(student);
        }



        [HttpPost]
        public IActionResult DeleteConfirmed(int StudentId)
        {
            try
            {
                var student = StudentRepository.Students
                    .FirstOrDefault(s => s.StudentId == StudentId);

                if (student == null)
                {
                    return NotFound();
                }

                StudentRepository.Students.Remove(student);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}