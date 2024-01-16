using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data.Generic_interface;
using Data.Models;

namespace View.ViewModel
{
     public class BookViewer
    {
        public static void BookDetails()
        {
            Action<MemberInfo[]> print = members =>
            {
                foreach (MemberInfo member in members)
                {
                    Console.WriteLine(member);
                }
            };

            Type type = typeof(Book);
            print(type.GetProperties());
        }
    }
}
