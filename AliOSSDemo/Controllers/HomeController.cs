using AliOSSDemo.Common;
using AliOSSDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliOSSDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(RegistrationModel mRegister)
        {
            //Check server side validation using data annotation
            if (ModelState.IsValid)
            {
                //TO:DO
                var fileName = Path.GetFileName(mRegister.file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                mRegister.file.SaveAs(path);
                var success = OSSHelper.Upload("cddt", "Content/Images/" + fileName, path);
                ViewBag.Message = "File has been uploaded successfully";
                ModelState.Clear();
            }
            return RedirectToAction("Index");
        }
    }
}