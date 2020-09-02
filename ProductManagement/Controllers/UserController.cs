using ProductManagement.Business.Manager.Interface;
using ProductManagement.Common;
using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class UserController : Controller
    {

        IUserManager manager;
        public UserController(IUserManager _manager)
        {
            manager = _manager;
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!manager.CheckEmail(user.EmailId))
                    {
                        string subject = "About Activation";
                        string body = "<html>" +
                            "<body><h2>Dear " + user.Name + "!!!</h2>" +
                            "<a href=https://localhost:44302/User/Activation?Email=" + user.EmailId + " >Click Here to activate your account</a>" +
                            "</body></html>";
                        if (Helper.SendMail(user.EmailId, subject, body))
                        {
                            manager.CreateUser(user);
                            return RedirectToAction("Login");
                        }
                        ViewBag.SendMailError = "Something went wrong, Check your Email Address or try After Sometime";
                        return View(user);
                    }
                    ViewBag.DuplicateMailError = "Email Address is already Exist, Try to login";
                    return View(user);
                }
                return View(user);
            }
            catch
            {
                return View(user);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Activation(string email)
        {
            if(manager.Activate(email))
                ViewBag.Activation = "Your Account is successfully Activated now";
            else
                ViewBag.Activation = "Your Account is Already activated try to login";
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserName"] != null)
                return RedirectToAction("Index", "Home");
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            try
            {
                if (user.EmailId != null && user.Password != null)
                {
                    UserViewModel userView = manager.Login(user);
                    if (userView != null)
                    {
                        if (userView.Status)
                        {
                            Session["UserName"] = userView.Name;
                            Session["UserId"] = userView.id;
                            return RedirectToAction("Index", "Product");
                        }
                        ViewBag.error = "Your Account is not Active go to your email and Activete your Account";
                    }
                    else
                    {
                        ViewBag.error = "Invalid Email or password";
                        return View(user);
                    }
                }
                return View(user);
            }
            catch
            {
                return View(user);
                throw;
            }
            
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            Session["UserName"] = null;
            Session["UserId"] = null;
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public ActionResult CheckEmail(string email)
        {
            if (manager.CheckEmail(email))
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(manager.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (manager.Edit(user))
                        return RedirectToAction("Index", "Product");
                    return View(user);
                }
                return View(user);
            }
            catch
            {
                return View(user);
                throw;
            }
        }
    }
}
