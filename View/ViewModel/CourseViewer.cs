using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModel
{
    public static class CourseViewer
    {
        public static void CourseDetails()
        {
            Action<MemberInfo[]> print = members =>
            {
                foreach (MemberInfo member in members)
                {
                    Console.WriteLine(member);
                }
            };

            Type type = typeof(Course);
            print(type.GetProperties());
        }
    }
}
