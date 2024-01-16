﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User : EntityBase
    {

        public virtual PersonalInformation? Information { get; set; }

        public virtual Login Login { get; set; }

        public List<Course> Courses { get; } = new();
    }
}
