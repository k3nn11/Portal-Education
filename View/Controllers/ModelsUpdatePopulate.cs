using Data.Generic_interface;
using Data.Models;
using Services.MaterialPopulation;
using Services.SkillPopulation;
using Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Controllers
{
    public static class ModelsUpdatePopulate
    {
        private static readonly ISkillPopulationService skillPopulation;
        private static readonly IMaterialPopulationService materialPopulation;
        public static Article UpdateArticle()
        {
            var validation = new ValidationService();
            Article article = new Article();
            Console.WriteLine(" Enter the information for Article material\nUse the format below");
            Console.WriteLine("Title, description, dateofPublication, resource");
            string title = Console.ReadLine();
            string description = Console.ReadLine();
            DateTime dateOfPublication = validation.ValidationDate();
            string resource = Console.ReadLine();
            article.Title = title;
            article.Description = description;
            article.DateOfPublication = dateOfPublication;
            article.Resource = resource;
            return article;
        }

        public static Book UpdateBook()
        {
            var book = new Book();
            var validation = new ValidationService();
            Console.WriteLine(" Enter the information for Book material\nUse the format below");
            Console.WriteLine("Title,description, Format, NumberofPages, Authors, YearOfPublication");
            book.Title = Console.ReadLine();
            book.Description = Console.ReadLine();
            book.Format = Console.ReadLine();
            book.NumberOfPages = validation.ValidationInterger();
            List<string> authors = new List<string>();
            Console.WriteLine("Enter authors to the list ( Enter 'q' when finish)");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "q")
                {
                    break;
                }

                authors.Add(userInput);
            }

            book.Authors = authors;

            return book;
        }

        public static Video UpdateVideo()
        {
            var video = new Video();
            var validation = new ValidationService();
            Console.WriteLine(" Enter the information for Video material\nUse the format below");
            Console.WriteLine("Title, description, Duration, Quality");
            video.Title = Console.ReadLine();
            video.Description = Console.ReadLine();
            video.Duration = validation.ValidationDecimal();
            video.Quality = Console.ReadLine();
            return video;
        }

        public static Skill UpdateSkill()
        {
            Console.WriteLine("Enter the fields information in the following format");
            Console.WriteLine("Title, Description");
            var skill = new Skill
            {
                Title = Console.ReadLine(),
                Description = Console.ReadLine(),
                Level = 1
            };
            return skill;
        }

        public static async Task<Course> UpdateCourse()
        {
            Course course = new Course();
            Console.WriteLine(" Enter the information for Course material\nUse the format below");
            Console.WriteLine("Title, Description, Skill, Type of material");
            course.Title = Console.ReadLine();
            course.Description = Console.ReadLine();
            course.Skills = await skillPopulation.PopulateSkill();
            course.Articles = await materialPopulation.PopulateArticle();
            course.Books = await materialPopulation.PopulateBook();
            course.Videos = await materialPopulation.PopulateVideo();
            return course;
        }
    }
}
