using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Generic_interface;
using Data.Models;
using Services.Validation;

namespace View.ViewModel
{
    public static class UserView
    {

        public static async Task ViewAvailableCourses(int? id)
        {
            Course course2 = new Course();
            Repository<Course> courseRepository = new Repository<Course>();
            List<Course> completedCourses = await ViewCompletedCourses();
            List<Course> InProgressCourses = await ViewCoursesInProgress(); 
            if (id.HasValue)
            {
                Course course1 = await courseRepository.GetByID(id.Value);
                Console.WriteLine($"Course by Id: {course1.Title}");
            }
            List<Course> courses = await courseRepository.GetAll();
            //User user = new User();
            Console.WriteLine("List of available courses");
            foreach (var course in courses)
            {
                if (!completedCourses.Contains(course) && !InProgressCourses.Contains(course))
                {
                    Console.WriteLine($"Available course: {course.Title}");
                }
            }
        }

        public static async Task<List<Course>> ViewCompletedCourses()
        {
            List<Course> courses = new List<Course>();
            Console.WriteLine("Completed Courses:");
            Repository<User> userRepository = new Repository<User>();
            User user = new User();
            List<User> users = await userRepository.GetAll();
            if (users != null)
            {
                foreach (User user1 in users)
                {
                    foreach(Course course in user1.CompletedCourses)
                    {
                        Console.WriteLine($"- {course.Title}");
                        courses.Add(course);
                    }
                    
                }
                return courses;
            }
            else
            {
                await Console.Out.WriteLineAsync("Users is empty");
                return null;
            }
        }

        public static async Task<List<Course>> ViewCoursesInProgress()
        {
            List<Course> courses = new List<Course>();
            Console.WriteLine("Courses in Progress:");
            Repository<User> userRepository = new Repository<User>();
            User user = new User();
            List<User> users = await userRepository.GetAll();
           if (users != null)
            {
                foreach (var user1 in users)
                {
                    foreach ( Course course in user1.CompletedCourses)
                    {
                        Console.WriteLine($"- {course.Title}");
                        await Console.Out.WriteLineAsync($"- {course.CompletionPercentage}");
                    }
                }
                return courses;
            }
            else
            {
                await Console.Out.WriteLineAsync("Users is empty");
                return null;
            }
        }

        public static async Task PersonalInfo()
        {
            Repository<PersonalInformation> userRepository = new Repository<PersonalInformation>();
            PersonalInformation information = await userRepository.GetByID(RequestId());
            if (information != null)
            {
                await Console.Out.WriteLineAsync($"Name of user: {information.Name}");
                foreach (var skill in information.Skills)
                {
                    await Console.Out.WriteLineAsync($"Skill: {skill}");
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("The Id does not exist");
            }   
        }



        private static int RequestId()
        {
            ValidationService validationService = new ValidationService();
            Console.WriteLine("Enter Id of User to Read");
            int id = validationService.ValidationInterger();
            return id;
        }
    }
}
