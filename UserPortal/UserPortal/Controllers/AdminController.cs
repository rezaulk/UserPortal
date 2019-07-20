using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserPortal.Core.Entities;
using UserPortal.Core.Services.Interfaces;
using UserPortal.Models;

namespace UserPortal.Controllers
{
    public class AdminController : Controller
    {
        public IUserPortalService _UserPortalService;

        public AdminController()
        {

        }
        public AdminController(IUserPortalService userPortal)
        {
            _UserPortalService = userPortal;
        }
        // GET: Admin
        public ActionResult UserList()
        {

            List<User> user = _UserPortalService.GetAllUser();

            List<UserModel> usermodel = new List<UserModel>();

            foreach( User s in user)
            {
                UserModel u = new UserModel();

                u.FirstName = s.FirstName;
                u.LastName = s.LastName;
                u.Phone = s.Phone;
                u.age = Convert.ToInt32(DateTime.Now.Year - s.BirthDate.Year);
                u.Email = s.Email;


                usermodel.Add(u);

            }

            ViewBag.User = usermodel;
            return View();
        }
    }
}