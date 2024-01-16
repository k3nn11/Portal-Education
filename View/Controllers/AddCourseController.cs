using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.CoursePopulation;
using Services.MaterialPopulation;

namespace View.Controllers
{
    public static class AddCourseController
    {
        private static readonly ICoursePopulationService coursePopulationService;
        public static async Task AddCourse()
        {
            //var coursePopulation = new CoursePopulationService();
            while (true)
            {
                CourseAddOptions();
                bool isValid = int.TryParse(Console.ReadLine(), out int input);
                if (isValid)
                {
                    if (input == 3)
                    {
                        break;
                    }

                    switch (input)
                    {
                        case 1:
                            await coursePopulationService .PopulateCourseFromSystem();
                            Console.WriteLine("Sucessfully added");
                            break;
                        case 2:
                            await coursePopulationService.PopulateCourseFromUser();
                            Console.WriteLine("Sucessfully Added");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid input");
                    continue;
                }
            }
        }

        private static void CourseAddOptions()
        {
            Console.WriteLine("Enter the method to populate the Course (Enter 3 to finish adding Courses):");
            Console.WriteLine("1: Populate course with material from the system");
            Console.WriteLine("2: Populate the course from User input");
        }
    }
}
