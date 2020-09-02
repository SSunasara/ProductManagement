using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProductManagement.Entity.ViewModels
{
    public class ProductViewModel
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public float Price { get; set; }
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public float Discount { get; set; }

        public string ImageName { get; set; }
        public string ImageContentType { get; set; }
        public byte[] ImageData { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Category { get; set; }
        public string User { get; set; }
    }
}
