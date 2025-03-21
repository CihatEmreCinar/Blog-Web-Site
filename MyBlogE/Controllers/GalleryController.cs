using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using PagedList;

namespace MyBlogE.Controllers
{
    public class GalleryController : Controller
    {
        GalleryManager gm = new GalleryManager();

        // GET: Gallery
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult GalleryList(int page = 1)
        {
            int pageSize = 8; // Sayfa başına 8 fotoğraf gösterilecek
            var gallery = gm.GetAll().ToPagedList(page, pageSize);

            return PartialView(gallery);
        }
    }
}