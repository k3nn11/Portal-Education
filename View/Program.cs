using Data.Models;
using Services.Authentication;
using Services.CoursesService;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Controllers;
using View.ViewModel;
using Services.ArticleService;
using Services.MaterialService;
using Data.Generic_interface;

namespace View
{
    internal class Program
    {
        private static readonly IRepository<Article> _articleRepository;
        public static async Task Main(string[] args)
        {
            //ArticleService _articleService = new ArticleService(_articleRepository);
            //List<Article> articles = await _articleService.GetArticleList();
            //foreach (Article article in articles)
            //{
            //    Console.WriteLine(article.Title);
            //}
            AuthService authService = new AuthService();
            //authService.CreateUser();
            //bool sd = true;
            bool authenticated = authService.Login();
            while (true)
            {
                if (authenticated)
                {
                    UserOptions();
                   int choice = int.Parse(Console.ReadLine());
                   switch(choice)
                    {
                        case 1:
                            await ViewProfile();
                            break;
                        case 2:
                            await UserInteractionAsync();
                            break;

                    }
                }
                else
                {
                    authService.CreateUser();
                }

                Console.WriteLine("Press 'L' to log out or any other key to continue.");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.L)
                {
                    break;
                }

                Console.WriteLine();
            }
        }

        private static async Task ViewProfile()
        {
            UserProfileOptions();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    await UserView.PersonalInfo();
                    break;
                case 2:
                    await UserView.ViewAvailableCourses(null);
                    break;
                case 3:
                    await UserView.ViewCompletedCourses();
                    break;
                case 4:
                    await UserView.ViewCoursesInProgress();
                    break;
                //case 5:
                //    await UserView.ViewNotStartedCourses();
                //    break;
                default:
                    await Console.Out.WriteLineAsync("Choose a valid choice");
                    break;

            }
        }
        private static async Task UserInteractionAsync()
        {
            ChoiceOptions();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    await AddMaterialController.AddMaterial();
                    break;

                case 2:
                    await AddSkillController.AddSkill();
                    break;
                case 3:
                    await AddCourseController.AddCourse();
                    break;
                case 4:
                    await AddUsercontroller.UserExecution();
                    break;
                case 5:
                    await ReadController.ReadMaterial();
                    break;
                case 6:
                    await UpdateController.UpdateMaterial();
                    break;
                case 7:
                    await DeleteController.DeleteMaterial();
                    break;
                case 8:
                    ViewModels.ModelOptions();
                    break;
                //case 9:
                //    await UserController.UserExecution();
                //    break;
            }
        }


        private static void ChoiceOptions()
        {
            Console.WriteLine("Enter the functionality you would like to execute");
            Console.WriteLine("1: AddMaterial");
            Console.WriteLine("2: AddSkill");
            Console.WriteLine("3: AddCourse");
            Console.WriteLine("4: AddUserDetails");
            Console.WriteLine("5: Readmaterial");
            Console.WriteLine("6: UpdateMaterial");
            Console.WriteLine("7: Delete Material");
            Console.WriteLine("8: View models");
            Console.WriteLine("9: USerInteraction");
        }

        private static void UserOptions()
        {
            Console.WriteLine("Enter the Functinality to perform:");
            Console.WriteLine("1: View User Profile");
            Console.WriteLine("2: User Interaction");

        }

        private static void UserProfileOptions()
        {
            Console.WriteLine("Enter the profile to View");
            Console.WriteLine("1: Personal Infomation");
            Console.WriteLine("2: View available courses");
            Console.WriteLine("3: View Completed courses");
            Console.WriteLine("4: View n progress courses");
        }
    }
}
