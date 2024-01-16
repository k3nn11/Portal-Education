using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserCourseServices
{
    public interface ICourseService
    {
        Task<List<Course>> SetCourseAsync();

        Task InProgressCourses();

        Task GetPercentage<T>(T entity) where T : EntityBase;

        Task CompletedCourses();

    }
}
