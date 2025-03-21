using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MyBlogE.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManger userProfile = new UserProfileManger();
        BlogManager bm = new BlogManager(new EfBlogDal());
        Context c = new Context();

        public ActionResult Index(string p)
        {
          
            return View();
        }
       public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var profilevalues = userProfile.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id =c.Authors.Where(x=>x.Mail==p).Select(y=>y.AuthorID).FirstOrDefault();   
            var blogs =userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var blog = c.Blogs.Include("Author").Include("Category").FirstOrDefault(x => x.BlogID == id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            ViewBag.values = c.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();

            ViewBag.values2 = c.Authors.Select(x => new SelectListItem
            {
                Text = x.AuthorName,
                Value = x.AuthorID.ToString()
            }).ToList();

            return View(blog);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            var blog = c.Blogs.Include("Author").FirstOrDefault(x => x.BlogID == p.BlogID);
            if (blog == null)
            {
                return HttpNotFound();
            }

            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryID = p.CategoryID;

            if (p.AuthorID != 0)
            {
                blog.Author = c.Authors.Find(p.AuthorID);
            }

            blog.AuthorID = p.AuthorID;
            c.SaveChanges();
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()

                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.TAdd(b);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
        public ActionResult LogOut2()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("AdminLogin", "Login");
        }
    }
}
