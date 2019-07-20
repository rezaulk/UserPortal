using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UserPortal.Core.Entities;
using UserPortal.Core.Services.Interfaces;
using UserPortal.Models;

namespace UserPortal.Controllers
{
    public class AccountController : Controller
    {
        public IUserPortalService _UserPortalService;

        public AccountController( )
        {
           
        }
        public AccountController(IUserPortalService userPortal)
        {
            _UserPortalService = userPortal;
        }
 

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel v)
        {

            if (ModelState.IsValid)
            {
                User u = Mapper.Map<User>(v);

                User p=_UserPortalService.Login(u);
                if(p==null)
                {
                    if(v.Email == "admin@localhost.local" && v.Password == "admin")
                    {
                        Session["admin"] ="Admin";
                        return RedirectToAction("UserList", "Admin");
                    }
                    else
                    {
                        ViewBag.LoginStatus = "Wrong Email Password !!!";
                        return View();
                    }
                   
                }
                else
                {
                    Session["UserId"] = p.UserId;
                    return RedirectToAction("Dashboard","User");
                } 
            }
            else
            { 
                return View();
            }
             

        }


        public ActionResult Registration()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationViewModel v)
        {

            if(ModelState.IsValid)
            {
                if (_UserPortalService.GetUniqueEmail(v.Email))
                {
                    User u = Mapper.Map<User>(v);
 
                    _UserPortalService.Insert(u);
                    ModelState.Clear();

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.unique = "Already This Email Exits";
                }
              
            }
          
            return View();
            
            
        }



        public ActionResult Logout()
        {
            Session["UserId"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}