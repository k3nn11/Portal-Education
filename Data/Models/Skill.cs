using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Skill : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }

        public PersonalInformation? Information { get; set; }

        public List<Course> Courses { get; } = new();

        public void IncreaseLevel()
        {
            Level++;
        }
    }

}
