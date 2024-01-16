using Services.CoursesService;
using Services.PersonalInfo;
using Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Controllers
{
    public static class AddUsercontroller
    {
        public static async Task UserExecution()
        {
            PIPopulation population = new PIPopulation();
            CourseService courseService = new CourseService();
            ValidationService validationService = new ValidationService();
            UserOptions();
            int choice = validationService.ValidationInterger();
            switch (choice)
            {
                case 0:
                    await population.PersonalInfoPopulation();
                    break;
                case 1:
                    await courseService.StartCourseAsync();
                    break;
                case 2:
                    await courseService.AddInProgressCoursesAsync();
                    break;
                case 3:
                    await courseService.AddCompletePercentageAsync();
                    await courseService.AddCompletedCoursesAsync();
                    await population.SkillPopulation();
                    break;
                default:
                    await Console.Out.WriteLineAsync("Enter valid choice, 1, 2, or 3");
                    break;
            }
        }
        private static void UserOptions()
        {
            Console.WriteLine("Enter the functionality to execute");
            Console.WriteLine("1: To add Name");
            Console.WriteLine("2: Start a course");
            Console.WriteLine("3: View the course that you have enrolled in");
            Console.WriteLine("4: View the material in the course");
        }

    }
}
