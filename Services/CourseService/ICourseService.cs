using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CourseService
{
    public interface ICourseService
    {
        Task Create(List<Course> courses);

        Task Update(Course course);

        Task Delete(int id);

        Task<List<Course>> GetCourseList();

        Task<Course> GetCourseById(int id);

    }
}
