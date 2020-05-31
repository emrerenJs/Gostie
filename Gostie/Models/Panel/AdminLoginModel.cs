using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.Panel
{
    public class AdminLoginModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
