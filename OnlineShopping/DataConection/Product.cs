using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConection
{
    public class Product
    {
        public int ProdID { get; set; }
        [Display(Name = "Product Name")]
        public string ProdName { get; set; }
        public double Price { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
