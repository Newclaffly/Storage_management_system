using STRM_M.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace STRM_M.Controllers
{
    public class LoginController : Controller
    {
        STRMEntities db = new STRMEntities(); // declare goaldbal Database

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login_axis()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(sdt_member objUser)
        {
            if (ModelState.IsValid)
            {
                using (STRMEntities db = new STRMEntities())
                {
                    var obj = db.sdt_member.Where(a => a.ID.Equals(objUser.ID)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["GOALBAL_ID"] = obj.ID.ToString();
                        Session["NAME_ENG"] = obj.NameEng.ToString();
                        Session["SURENAME_ENG"] = obj.SurnameEng.ToString();
                        Session["POSITION"] = obj.Position.ToString();
                        Session["PERMISSION"] = obj.Position.ToString();
                        Session["Level"] = obj.Level.ToString();
                        return RedirectToAction("Index", "Home");
                        //return Json(new { data = obj }, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        ViewBag.Message = "";
                        return View();
                    }
                }
            }
            return View(objUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login_axis(Model_Search axis)
        {
            if (ModelState.IsValid)
            {
                using (STRMEntities db = new STRMEntities())
                {
                    var obj_axis = db.sp_login_axis().Where(a => a.EMP_ID.Equals(axis.emp_id) && a.PASSWORD.Equals(axis.password_axis)).FirstOrDefault();
                    //var obj_axis = db.sp_login_axis().Where(a => a.EMP_ID.Equals(axis.emp_id)).FirstOrDefault();
                    if (obj_axis != null)
                    {
                        Session["GOALBAL_ID"] = obj_axis.EMP_ID.ToString();
                        Session["PASSWORD"] = obj_axis.PASSWORD.ToString();
                        Session["NAME_ENG"] = obj_axis.EMP_NAME.ToString();
                        Session["SURENAME_ENG"] = obj_axis.EMP_NAME.ToString();
                        Session["POSITION"] = obj_axis.DEPARTMENT_CODE.ToString();
                        Session["PERMISSION"] = "AXIS";
                        Session["Level"] = "1";
                        return RedirectToAction("Index", "Home");
                        //return Json(new { data = obj_axis }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ViewBag.Message = "";
                        return View();
                    }
                }
            }
            return View(axis);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login_axis", "Login");
        }

    }
}