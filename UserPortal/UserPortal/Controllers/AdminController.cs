using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserPortal.Core.Entities;
using UserPortal.Core.Services.Interfaces;

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

            ViewBag.User = user;
            return View();
        }
    }
}