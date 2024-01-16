using Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModel
{
    public static class ViewModels
    {
        public static void ModelOptions()
        {
            ViewModeloptions();
            ValidationService validation = new ValidationService();
            int choice = validation.ValidationInterger();
            switch (choice)
            {
                case 1:
                    ArticleViewer.ArticleDetails();
                    break;
                case 2:
                    BookViewer.BookDetails();
                    break;
                case 3:
                    CourseViewer.CourseDetails();
                    break;
                case 4:
                    SkillViewer.SkillDetails();
                    break;
                case 5:
                    VideoViewer.VideoDetails();
                    break;
                default:
                    Console.WriteLine("error, wrong choice");
                    break;
            }
        }

        private static void ViewModeloptions()
        {
            Console.WriteLine("Enter model to view");
            Console.WriteLine("1: Article");
            Console.WriteLine("2: Book");
            Console.WriteLine("3: Course");
            Console.WriteLine("4: Skill");
            Console.WriteLine("5: Video");
        }
    }
}
