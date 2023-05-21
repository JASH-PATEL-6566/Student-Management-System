using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Standard { get; set; }
        public String Gender { get; set; }
    }
}