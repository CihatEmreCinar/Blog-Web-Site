using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MyBlogE.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        AuthorManager authormanager=new AuthorManager(new EfAuthorDal());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail=blogmanager.GetBlogByID(id);
            return PartialView(authordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid); // Blog listesini al
            return PartialView(authorblogs); // Listeyi döndür
        }

        public ActionResult AuthorList()
        {
          var authorlist =  authormanager.GetList();
            return View(authorlist);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            AuthorValidator authoryvalidator = new AuthorValidator();
            ValidationResult result = authoryvalidator.Validate(p);
            if (result.IsValid)
            {
                authormanager.TAdd(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id) 
        {
            Author author = authormanager.GetByID(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p) 
        {
            AuthorValidator authoryvalidator = new AuthorValidator();
            ValidationResult result = authoryvalidator.Validate(p);
            if (result.IsValid)
            {
                authormanager.TUpdate(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}