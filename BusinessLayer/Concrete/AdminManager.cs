using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager
    {
        Repository<Admin> repoadmin = new Repository<Admin>();
        public List<Admin> GetAll()
        {
            return repoadmin.List();
        }
        public List<Admin> GetBlogByID(int id)
        {
            return repoadmin.List(x => x.AdminID == id);
        }
    }
}
