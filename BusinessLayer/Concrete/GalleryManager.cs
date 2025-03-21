using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GalleryManager
    {
        Repository<Gallery> repogallery = new Repository<Gallery>();

        public List<Gallery> GetAll()
        {
            return repogallery.List();
        }
        public List<Gallery> GetGalleryByID(int id)
        {
            return repogallery.List(x => x.GalleryID == id);
        }
        public void AddGalleryBL(Gallery g)
        {
            //if (g.ImagePath == "" || g.Title == "" )
            //{
            //    return -1;
            //}
             repogallery.Insert(g);
        }
        public void DeleteGalleryBL(int g)
        {
            Gallery gallery = repogallery.Find(x => x.GalleryID == g);
             repogallery.Delete(gallery);

        }
    }
}
