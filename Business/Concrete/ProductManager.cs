using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _prductDal;

        public ProductManager(IProductDal prductDal)
        {
            _prductDal = prductDal;
        }

        public List<Product> GetAll()
        {
            return _prductDal.GetAll();
            
        }
    }
}
