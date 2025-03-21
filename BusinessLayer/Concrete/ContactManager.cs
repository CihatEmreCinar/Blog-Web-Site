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
    public class ContactManager:IContactService
    {
        IContactDal _contactDal;


        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public Contact GetByID(int id)
        {
            return _contactDal.Find(x=>x.ContanctID==id);
        }
        public List<Contact> GetList()
        {
           return _contactDal.List();
        }
        public void TAdd(Contact t)
        {
            _contactDal.Insert(t);
        }
        public void TDelete(Contact t)
        {
            throw new NotImplementedException();
        }
        public void TUpdate(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
