using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConection
{
    public class Cart
    {
        public string userId { get; set; }
        public int ProdID { get; set; }
        [Display(Name = "Prpduct name")]
        public string ProdName { get; set; }
        [Display(Name ="image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Item Price")]
        public double EachPrice { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Total price")]
        public double Total { get; set; }

    }
}
