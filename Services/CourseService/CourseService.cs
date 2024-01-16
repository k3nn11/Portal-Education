using Data.Generic_interface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        public CourseService(IRepository<Course> courseRepository) 
        {
            _courseRepository = courseRepository;
        }

        public async Task Create(List<Course> courses)
        {
            if (courses != null && courses.Count > 0)
            {
                foreach (var course in courses)
                {
                    await _courseRepository.Create(course);
                }
            }
        }

        public async Task Delete(int id)
        {
            await _courseRepository.Delete(id);
        }

        public Task<Course> GetCourseById(int id)
        {
            return _courseRepository.GetByID(id);
        }

        public Task<List<Course>> GetCourseList()
        {
            return _courseRepository.GetAll();
        }

        public Task Update(Course course)
        {
           return _courseRepository.Update(course);
        }
    }
}
