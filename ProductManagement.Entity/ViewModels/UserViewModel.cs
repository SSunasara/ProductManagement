using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Entity.ViewModels
{
    public class UserViewModel
    {
        public int id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20), MinLength(3)]
        [RegularExpression(@"^([a-zA-Z ]+)$", ErrorMessage = "Name Contain Only Characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email is not valid.")]
        public string EmailId { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter PhoneNumber as 0123456789, 012-345-6789, (012)-345-6789.")]
        public string Contact { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^([a-zA-Z]+)$", ErrorMessage = "City Contain Only Characters")]
        public string City { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^([a-zA-Z]+)$", ErrorMessage = "State Contain Only Characters")]
        public string State { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^([a-zA-Z]+)$", ErrorMessage = "Country Contain Only Characters")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Please enter 6 Digit Only")]
        public string Zipcode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "The Password must be atleast 8 characters")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CPassword { get; set; }

        public bool Status { get; set; }
    }
}
