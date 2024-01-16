using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Login : EntityBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual User User { get; set; }
    }
}
