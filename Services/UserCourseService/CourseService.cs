using Data.Generic_interface;
using Data.Models;

namespace Services.UserCourseServices
{

    public class CourseService : ICourseService
    {
        private readonly IRepository<User> _userRepository;
        private readonly Course _course;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Video> _videoRepository;

        public User User { get; private set; }

        public CourseService(Course course, IRepository<Course> courseRepository, IRepository<User> userRepository
, IRepository<Article> articleRepository, IRepository<Book> bookRepository, IRepository<Video> videoRepository)
        {
            _course = course;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _articleRepository = articleRepository;
            _bookRepository = bookRepository;
            _videoRepository = videoRepository;
        }


        public async Task<List<Course>?> SetCourseAsync()
        {
            User user = new();
            if (_course != null && !user.Courses.Contains(_course))
            {
                user.Courses.Add(_course);
                await _userRepository.Update(user);
                return (List<Course>)user.Courses;
            }
            return null;
        }

        public async Task InProgressCourses()
        {
            List<Course> courseList = await SetCourseAsync();
            foreach (Course course in courseList)
            {
                if (course.CompletionPercentage > 0)
                {
                    course.State = CourseState.InProgress;
                    await _courseRepository.Update(course);
                }
            }
        }

        public async Task CompletedCourses()
        {
            List<Course> courses = await SetCourseAsync();
            foreach (Course course in courses)
            {
                if (course.CompletionPercentage == 100)
                {
                    course.State = CourseState.Completed;
                    await _courseRepository.Update(course);

                }
            }
        }

        public async Task GetPercentage<T>(T entity) where T : EntityBase
        {
            int ReadCount = default;
            if (entity == null)
            {
                return;
            }
            List<Course> courses = await GetNotDeleted();
            foreach (var course in courses)
            {
                int materialCount = course.Articles.Count + course.Books.Count + course.Videos.Count;
                foreach (var article in course.Articles)
                {
                    if (article == entity)
                    {
                        await _articleRepository.GetByID(entity.Id);
                        article.IsDeleted = true;
                        ReadCount++;
                    }
                }
                foreach (var book in course.Books)
                {
                    if (course.Books == entity)
                    {
                        await _bookRepository.GetByID(entity.Id);
                        book.IsDeleted = true;
                        ReadCount++;
                    }
                }

                foreach (var video in course.Videos)
                {
                    if (course.Videos == entity)
                    {
                        await _videoRepository.GetByID(entity.Id);
                        video.IsDeleted = true;
                        ReadCount++;
                    }
                }

                int percentage = (ReadCount / materialCount) * 100;
                course.CompletionPercentage = percentage;
                await _courseRepository.Update(course);

            }
        }

        private async Task<List<Course>> GetNotDeleted()
        {
            List<Course> courses1 = new List<Course>();
            Course notDeletedCourse = new Course();
            List<Course> courses = await SetCourseAsync();
            foreach (var course in courses)
            {
                foreach (var article in course.Articles)
                    if (article.IsDeleted == false)
                    {
                        notDeletedCourse.Articles.Add(article);
                    }
                foreach (var book in course.Books)
                {
                    if (book.IsDeleted == false)
                    {
                        notDeletedCourse.Books.Add(book);
                    }
                }
                foreach (var video in course.Videos)
                {
                    if (video.IsDeleted == false)
                    {
                        notDeletedCourse.Videos.Add(video);
                    }
                }

                courses1.Add(notDeletedCourse);
            }

            return courses1;
        }
    }
}
