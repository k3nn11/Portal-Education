using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   
    public class Article : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateOfPublication { get; set; }

        public string Resource { get; set; }

        public States States { get; set;}

        public bool IsDeleted { get; set; }

        public Course Course { get; set; }

    }
    public enum States
    {
        Completed = 0,
        InProgress = 1
    }


}
