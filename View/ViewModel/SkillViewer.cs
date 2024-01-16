using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModel
{
    public static class SkillViewer
    {
        public static void SkillDetails()
        {
            Action<MemberInfo[]> print = members =>
            {
                foreach (MemberInfo member in members)
                {
                    Console.WriteLine(member);
                }
            };

            Type type = typeof(Skill);
            print(type.GetProperties());
        }
    }
}
