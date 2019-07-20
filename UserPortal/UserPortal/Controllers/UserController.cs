using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UserPortal.Core.Entities;
using UserPortal.Core.Services.Interfaces;

namespace UserPortal.Controllers
{
    public class UserController : Controller
    {
        public IUserPortalService _UserPortalService;

        public UserController()
        {

        }
        public UserController(IUserPortalService userPortal)
        {
            _UserPortalService = userPortal;
        }


        string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        // GET: User
        public ActionResult Dashboard()
        {
            int k = Convert.ToInt32(Session["UserId"]);

            User U=_UserPortalService.GetUser(k);

            ViewBag.User = U;
            return View();
        }


        public ActionResult ChangePassword()
        {

            int k = Convert.ToInt32(Session["UserId"]);

            User U = _UserPortalService.GetUser(k);

            ViewBag.User = U;
            return View();
        }



        public JsonResult GetUserByKeyword(string Keyword)
        {
            List<User>User = _UserPortalService.GetAllUserBySearch(Keyword);
            return Json(User, JsonRequestBehavior.AllowGet);
        }


        public JsonResult UserPassChange(string prepass, string newpass)
        {
            int s = Convert.ToInt32(Session["UserId"]);

            User u = _UserPortalService.GetUser(s);

            string status = "";
            if(CalculateMD5Hash(prepass) == u.Password)
            {
                if(_UserPortalService.InsertNewPassword(s,newpass))
                {
                    status = "Successfully Changed";
                }
                else
                {
                    status = "Successfully Changed";
                } 
            }
            else
            {
                status = "Password Not Match";
            }
          
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        
    }
}