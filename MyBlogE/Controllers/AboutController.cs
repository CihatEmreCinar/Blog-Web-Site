using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MyBlogE.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboucontent = abm.GetList();
            return View(aboucontent);
        }
        public PartialViewResult Footer()
        {
           var aboutcontentlist= abm.GetList();

        return PartialView(aboutcontentlist);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman = new AuthorManager(new EfAuthorDal());
            var authorList= autman.GetList();
            return PartialView(authorList);
        }
        public ActionResult UpdateAboutList()
        {
            var aboutlist=abm.GetList();
            return View(aboutlist);
        }
        public ActionResult UpdateAbout(About p)
        {
            abm.TUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}