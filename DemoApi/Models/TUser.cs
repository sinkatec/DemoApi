using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    public class TUser
    {
        [Key]
        public string login_id { get; set; }
        public string password { get; set; }
    }
}
