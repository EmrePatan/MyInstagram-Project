using BusinessLayer;
using Entities;
using Entities.ValueObjects;
using MyInstagram.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyInstagram.Controllers
{
    public class AnasayfaController : Controller
    {
        public ActionResult HomePage()
        {
            StoryManager sm = new StoryManager();
            return View(sm.GetAllStories());
        }

        [HttpPost]
        public ActionResult AddStory(StoryVM storyVM)
        {
            StoryManager sm = new StoryManager();

            int UserID = (int)Session["ActiveUser"];
            if (storyVM != null)
            {
                if (Directory.Exists(Server.MapPath("~/files")) == false)
                    Directory.CreateDirectory(Server.MapPath("~/files"));

                string path = (Path.Combine(Server.MapPath("~/files"), storyVM.file.FileName));
                storyVM.file.SaveAs(path);
                sm.InsertStory(path,storyVM.StoryComment,UserID);
                return RedirectToAction("HomePage");
            }

            return View();
        }
        
        [HttpPost]
        public JsonResult AddComment(Comment Comment, int StoryID)
        {
            int UserID = (int)Session["ActiveUser"];
            Comment comment = new CommentManager().AddComment(Comment, UserID, StoryID);
            return Json(comment);
        }

        [HttpPost]
        public JsonResult AddLike(int StoryID)
        {
            StoryManager sm = new StoryManager();
            int LikeCount = sm.AddLike(StoryID);
            return Json(LikeCount);
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            UserManager um = new UserManager();
            int UserID = um.FindUserID(loginVM);
            if (UserID!=0)
            {
                Session.Add("ActiveUser", UserID);
                return RedirectToAction("HomePage");
            }
            else
            {
                ModelState.AddModelError("", "Kayıtlı Böyle Bir Kullanıcı Bulunmamaktadır." +
                    "Lütfen Bilgilerinizi Kontrol Edip Tekrar Deneyiniz.");
                return View(loginVM);
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("ActiveUser");
            return RedirectToAction("Login");
        }

        public ActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            UserManager um = new UserManager();

            if (ModelState.IsValid)
            {
                User User = um.ChechUser(registerVM);

                if (User!=null)
                {
                    um.NewUser(User);
                    TempData["Result"] = "success";
                    TempData["NewUser"] = string.Format("Sayın {0} {1} kaydınız başarıyla oluşturulmuştur.", User.Name, User.Surname);
                    return View();
                }
                else
                {
                    TempData["Result"] = "danger";
                    TempData["InUseUser"] = "Girmiş olduğunuz e-mail veya kullanıcı adı başka bir kullanıcı tarafından kullanılmaktadır.";
                }
            }
            return View("Register",registerVM);
        }
        
        [HttpPost]
        public JsonResult FileProfilPicture(HttpPostedFileBase file2)
        {
            FileProfilPicture fpp = new FileProfilPicture();

            if (file2 != null)
            {
                if (Directory.Exists(Server.MapPath("~/profilpictures")) == false)
                    Directory.CreateDirectory(Server.MapPath("~/profilpictures"));

                string path = (Path.Combine(Server.MapPath("~/profilpictures"), file2.FileName));
                file2.SaveAs(path);
                fpp.SaveImage(path);
                return Json(new { hasError = false, message = "Dosya yüklendi.." });
            }

            return Json(new { hasError = true, message = "Dosya null geldi." });
        }
    }
}