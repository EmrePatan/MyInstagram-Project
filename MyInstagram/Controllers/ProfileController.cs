using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyInstagram.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult ProfilePage()
        {
            UserManager um = new UserManager();
            User user = um.FindUser(1);
            return View(user);
        }
    }
}