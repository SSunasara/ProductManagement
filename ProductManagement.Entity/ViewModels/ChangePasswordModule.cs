using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Entity.ViewModels
{
    public class ChangePasswordModule
    {
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "The Password must be atleast 8 characters")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CPassword { get; set; }
    }
}
