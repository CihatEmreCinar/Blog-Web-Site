﻿using System;
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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authordal;
        //Tüm yazar listesini getirme
        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }
        public List<Author> GetList()
        {
            return _authordal.List();
        }

        public Author GetByID(int id)
        {
            return _authordal.GetById(id);
        }

        public void AboutDelete(Author author)
        {
            throw new NotImplementedException();
        }
        public void TAdd(Author t)
        {
            _authordal.Insert(t); ;
        }
        public void TDelete(Author t)
        {
            throw new NotImplementedException();
        }
        public void TUpdate(Author t)
        {
            _authordal.Update(t);
        }
    }
}
