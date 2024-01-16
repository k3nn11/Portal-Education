using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data.Generic_interface;
using Data.Models;
using Services.Authentication;
using Services.Validation;

namespace View.ViewModel
{
    public static class ArticleViewer
    {
        public static void ArticleDetails()
        {
            Action<MemberInfo[]> print = members =>
            {
                foreach (MemberInfo member in members)
                {
                    Console.WriteLine(member);
                }
            };

            Type type = typeof(Article);
            print(type.GetProperties());
        }
    }
}
