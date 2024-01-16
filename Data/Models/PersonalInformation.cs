using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PersonalInformation : EntityBase
    {

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public ICollection<Skill> Skills { get; }

        public virtual User User { get; set; }
    }
}
