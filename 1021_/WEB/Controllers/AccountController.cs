using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BLL;
using System.Web.Security;
using BOL;

namespace DocWebApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Doctor
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(string userName, string password, string returnUrl)
        {
            //if(userName =="ravi" && password == "seed")
            if (AccountManager.Validate(userName, password))
            {
                // return   this.RedirectToAction("index", "products");
                FormsAuthentication.SetAuthCookie(userName, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }
            else
            {
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string name, string speciality,double fee, string hospital,DateTime birthDate,string username,string password,string returnUrl)
        {
           if(AccountManager.Register(name,speciality,fee,birthDate,hospital,username,password))
            {
                // return   this.RedirectToAction("index", "products");
                //FormsAuthentication.SetAuthCookie(userName, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }
            else
            {
                return View();
            }
        }
        public ActionResult List()
        {
            List<Doctor> doclist = AccountManager.listAllDoc();
            ViewData["doclist"] = doclist;
            return View();


        }
        public ActionResult Delete(string userName,string returnUrl )
        {
            if (AccountManager.delete(userName))
            {
                return  Redirect(returnUrl ?? Url.Action("Login", "Account"));
            }
            else {
            return Redirect(returnUrl ?? Url.Action("List", "List"));
            }

        }
        public ActionResult update(string userName, string returnUrl)
        {
            return View(AccountManager.getByusername(userName));

        }
    }
}