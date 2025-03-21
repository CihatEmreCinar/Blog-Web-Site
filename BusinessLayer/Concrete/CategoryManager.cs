using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorDAL;
        public CategoryManager(ICategoryDal categorDAL)
        {
            _categorDAL = categorDAL;
        }   
        public void CategoryStatusFalseBL(int id)
        {
            Category category = _categorDAL.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            _categorDAL.Update(category);
        }
        public void CategoryStatusTrueBL(int id)
        {
            Category category = _categorDAL.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
            _categorDAL.Update(category);
        }
        public List<Category> GetList()
        {
            return _categorDAL.List();
        }
        public Category GetByID(int id)
        {
            return _categorDAL.GetById(id);
        }
        public void TAdd(Category t)
        {
            _categorDAL.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categorDAL.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categorDAL.Update(t);
        }
    }
}
