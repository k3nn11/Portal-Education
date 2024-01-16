using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Video : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Duration { get; set; }

        public  Quality Quality { get; set; }

        public bool IsDeleted { get; set; }

        public Course Course { get; set; }

    }

    public enum Quality
    {
        High,
        Medium,
        Low

    }
}