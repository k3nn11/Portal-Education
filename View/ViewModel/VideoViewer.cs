using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModel
{
    public static class VideoViewer
    {
        public static void VideoDetails()
        {
            Action<MemberInfo[]> print = members =>
            {
                foreach (MemberInfo member in members)
                {
                    Console.WriteLine(member);
                }
            };

            Type type = typeof(Video);
            print(type.GetProperties());
        }
    }
}
