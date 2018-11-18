using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataConection;

namespace OnlineShopping.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        DataConection.DataConection dataConection = new DataConection.DataConection();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> prod = dataConection.GetProducts.ToList();
            return View(prod);
        }

        // GET: Product/Details/5
        public ActionResult AddOrCreate(int id,string userid)
        {
            if(dataConection.getProdFromCart(userid,id).Count()>0)
            {
                return RedirectToAction("Edit_Cart",new { @userid = userid, @id = id });
            }
            return RedirectToAction("AddToCart",new { @id = id });
            //return View();
        }

        [HttpGet]
        public ActionResult userCart(string userid)
        {
            string userId = userid ?? User.Identity.Name;
            List<Cart> carts = dataConection.getProdFromCartForUser(userId).ToList();
            
            return View(carts);
            
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            Product prd = dataConection.GetProducts.Single(x => x.ProdID == id);
            Cart ct = new Cart();

            ct.ProdID = prd.ProdID;
            ct.ProdName = prd.ProdName;
            ct.ImageUrl = prd.ImageUrl;
            ct.EachPrice = prd.Price;
            ct.Quantity = 0;
            ct.Total = 0;

            return View(ct);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult AddToCart(Cart cart)
        {
            cart.userId = User.Identity.Name;
            cart.Total = (Convert.ToDouble(cart.EachPrice) * cart.Quantity);
            dataConection.AddToCart(cart);
            return RedirectToAction("userCart", new { @userid = cart.userId, @id = cart.ProdID });
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit_Cart(string userId, int id)
        {
            Cart ct = dataConection.getProdFromCart(userId, id).FirstOrDefault();
            return View(ct);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit_Cart(Cart cart)
        {
            //userId = User.Identity.Name.ToString();
            //dataConection.getProdFromCart(userId, id);
            cart.userId = User.Identity.Name;
            cart.Total = (Convert.ToDouble(cart.EachPrice) * cart.Quantity);
            dataConection.EditCart(cart.userId, cart.ProdID, cart.Quantity,cart.Total);

            return RedirectToAction("userCart", new { @userid =cart.userId, @id = cart.ProdID });

        }

      
        
        public ActionResult Delete(int id, string userid)
        {
            dataConection.DeleteCart(id, userid);
            if (dataConection.getProdFromCartForUser(userid).Count() > 0)
            {
                return RedirectToAction("userCart", new { @userid = userid });
            }
            return RedirectToAction("Index");
        }
    }
}
