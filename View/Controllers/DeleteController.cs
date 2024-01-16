using Data.Generic_interface;
using Data.Models;
using Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Controllers
{
    public static class DeleteController
    {
        private static ValidationService _validationService = new ValidationService();

        public static async Task DeleteMaterial()
        {
            Repository<Article> articleRepository = new Repository<Article>();
            Repository<Book> bookRepository = new Repository<Book>();
            Repository<Video> videoRepository = new Repository<Video>();
            Repository<Skill> skillRepository = new Repository<Skill>();
            Repository<Course> courseRepository = new Repository<Course>();
            DeleteOptions();
            //Console.WriteLine("Enter the material to read from the list below");
            int choice = _validationService.ValidationInterger();
            switch (choice)
            {
                case 1:
                    int articleId = RequestId();
                    await articleRepository.Delete(articleId);
                    break;
                case 2:
                    int bookId = RequestId();
                    bookRepository.Delete(bookId);
                    break;
                case 3:
                    int videoId = RequestId();
                    await videoRepository.Delete(videoId);
                    break;
                case 4:
                    int skillId = RequestId();
                    await skillRepository.Delete(skillId);
                    break;
                case 5:
                    int courseId = RequestId();
                    await courseRepository.Delete(courseId);
                    break;
            }
        }

        private static void DeleteOptions()
        {
            Console.WriteLine("Enter the material to delete");
            Console.WriteLine("1: delete Article");
            Console.WriteLine("2: delete Book");
            Console.WriteLine("3: delete Video");
            Console.WriteLine("4: delete skill");
            Console.WriteLine("5: delete Course");
        }

        private static int RequestId()
        {
            Console.WriteLine("Enter Id of material to delete");
            int id = _validationService.ValidationInterger();
            return id;
        }
    }
}
