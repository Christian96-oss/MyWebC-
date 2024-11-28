using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYWEB.Models
{
    public class LoginModel
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string level { get; set; }
        public string apps { get; set; }
    }
}
