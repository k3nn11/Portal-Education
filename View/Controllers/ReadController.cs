using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Generic_interface;
using Data.Models;
using Services.Validation;
using View.ViewModel;

namespace View.Controllers
{
    public static class ReadController
    {
        public static async Task ReadMaterial()
        {
            Repository<Article> articleRepository = new Repository<Article>();
            Repository<Book> bookRepository = new Repository<Book>();
            Repository<Video> videoRepository = new Repository<Video>();
            Repository<Skill> skillRepository = new Repository<Skill>();
            Repository<Course> courseRepository = new Repository<Course>();
            ValidationService validationService = new ValidationService();
            ReadOptions();
            //Console.WriteLine("Enter the material to read from the list below");
            int choice = validationService.ValidationInterger();
            switch (choice)
            {
                case 1:
                    //Console.WriteLine("Enter material ID");
                    int id = RequestId();
                    Article article = await articleRepository.GetByID(id);
                    Console.WriteLine(article.Id + " " + article.Title + " " + article.Resource + " " + article.DateOfPublication);
                    break;
                case 2:
                    int id1 = RequestId();
                    //await bookRepository.GetByID(id1);
                    Book book = await bookRepository.GetByID(id1);
                    Console.WriteLine(book.Id + " " + book.Title + " " + book.Description + " " + book.Authors + " " + book.Format);
                    break;
                case 3:
                    int id2 = RequestId();
                    //await videoRepository.GetByID(id2);
                    Video video = await videoRepository.GetByID(id2);
                    Console.WriteLine(video.Id + " " + video.Title + " " + video.Description + " " + video.Quality);
                    break;
                case 4:
                    int id3 = RequestId();
                    Skill skill = await skillRepository.GetByID(id3);
                    Console.WriteLine(skill.Id + " " + skill.Level + " " + skill.Title + " " + skill.Description);
                    break;
                case 5:
                    int id4 = RequestId();
                    //await courseRepository.GetByID(id4);
                    Course course = await courseRepository.GetByID(id4);
                    Console.WriteLine(course.Id + " " + course.Title + " " + course.Description);
                    break;
            }
        }

        private static void ReadOptions()
        {
            Console.WriteLine("Enter the material you would like to read from");
            Console.WriteLine("1: Read Article Material");
            Console.WriteLine("2: Read Book Material");
            Console.WriteLine("3: Read Video Material");
            Console.WriteLine("4: Read Skill material");
            Console.WriteLine("5: Read Course material");
        }

        private static int RequestId()
        {
            ValidationService validationService = new ValidationService();
            Console.WriteLine("Enter Id of material to Read");
            int id = validationService.ValidationInterger();
            return id;
        }
    }
}
