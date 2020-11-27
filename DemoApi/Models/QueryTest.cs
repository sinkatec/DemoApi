using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    public class QueryTest
    {
        [Key]
        public string dept_name { get; set; }
    }
}
