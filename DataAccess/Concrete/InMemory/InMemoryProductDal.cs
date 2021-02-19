using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="bardak", UnitePrice=15, UnitInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="kamera", UnitePrice=500, UnitInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="telefon", UnitePrice=1500, UnitInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="klavye", UnitePrice=150, UnitInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="fare", UnitePrice=85, UnitInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            /*foreach (var p in _products)
            {
                if(product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }*/

            // LİNQ
            productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); // ya da First kullanılır.



            _products.Remove(productToDelete);
        }

        
        
        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); // ya da First kullanılır.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            product.UnitePrice = product.UnitePrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
