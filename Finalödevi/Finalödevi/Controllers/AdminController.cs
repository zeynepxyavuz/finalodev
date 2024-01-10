using Finalödevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finalödevi.Controllers
{
    public class AdminController : Controller
    {
        eğitimplatformDBEntities db = new eğitimplatformDBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Kurslar.ToList();
            return View(sorgu);
        }

        public ActionResult login() 
        { 
            
            
            return View(); 
        
        
        }
        [HttpPost]
        public ActionResult login(Admin admin)
        {

            var login = db.Admin.Where(x=>x.eposta==admin.eposta).SingleOrDefault();
            if (login.eposta == admin.eposta && login.sifre==admin.sifre)
            {
                Session["adminid"]=login.adminId;
                Session["eposta"]= login.eposta;
                return RedirectToAction("Index","Admin");
            }
            ViewBag.uyari = "Kullanıcı adı ya da Şifre hatalı";
            return View();


        }
    }
}