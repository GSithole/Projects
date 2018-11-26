using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataConection;
namespace OnlineShopping.Controllers
{
    public class LoginController : Controller
    {
        DataConection.DataConection db = new DataConection.DataConection();
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName,string passwrd,string ReturnUrl)
        {
            if (db.GetUser(userName, passwrd).Count() > 0)
            {
                User us = db.GetUser(userName, passwrd).FirstOrDefault();
                FormsAuthentication.SetAuthCookie(us.userName, false);
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            else
            {
                return View(userName,passwrd);
            }
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Login/Create
        [HttpGet]
        public ActionResult Register()
        {
            
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if(db.ValidateUser(user.userName,user.password).Count() > 0)
                {
                    return View("Register_Error");
                }
                db.AddUser(user);
               return  RedirectToAction("Login");
            }
            return View();
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
