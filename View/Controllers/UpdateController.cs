using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Generic_interface;
using Data.Models;
using Services.Validation;

namespace View.Controllers
{
    public static class UpdateController
    {
        // to do
        // how to pass article in the article params.
        private static ValidationService _validationService = new ValidationService();

        public static async Task UpdateMaterial()
        {
            Repository<Article> articleRepository = new Repository<Article>();
            Repository<Book> bookRepository = new Repository<Book>();
            Repository<Video> videoRepository = new Repository<Video>();
            Repository<Skill> skillRepository = new Repository<Skill>();
            Repository<Course> courseRepository = new Repository<Course>();
            //Console.WriteLine("Enter the material to read from the list below");
            UpdateOptions();
            int choice = _validationService.ValidationInterger();
            switch (choice)
            {
                case 1:
                    int articleId = RequestId();
                    Article article = ModelsUpdatePopulate.UpdateArticle();
                    articleRepository.Update(articleId, article);
                    break;
                case 2:
                    int bookId = RequestId();
                    Book book = ModelsUpdatePopulate.UpdateBook();
                    await bookRepository.Update(bookId, book);
                    break;
                case 3:
                    int videoId = RequestId();
                    Video video = ModelsUpdatePopulate.UpdateVideo();
                    await videoRepository.Update(videoId, video);
                    break;
                case 4:
                    int skillId = RequestId();
                    Skill skill = ModelsUpdatePopulate.UpdateSkill();
                    await skillRepository.Update(skillId, skill);
                    break;
                case 5:
                    int courseId = RequestId();
                    Course course = await ModelsUpdatePopulate.UpdateCourse();
                    await courseRepository.Update(courseId, course);
                    break;
            }
        }

        private static void UpdateOptions()
        {
            Console.WriteLine("Enter the material to update");
            Console.WriteLine("1: Update Article");
            Console.WriteLine("2: Update Book");
            Console.WriteLine("3: Update Video");
            Console.WriteLine("4: Update skill");
            Console.WriteLine("5: Update Course");
        }

        private static int RequestId()
        {
            Console.WriteLine("Enter Id of material to Update");
            int id = _validationService.ValidationInterger();
            return id;
        }
    }
}
