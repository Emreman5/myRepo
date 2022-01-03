using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepository<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDTo> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                            join c in context.Categories
                            on p.CategoryId equals c.CategoryId
                            select new ProductDetailDTo
                            {
                                ProductId = p.ProductId,
                                CategoryName = c.CategoryName,
                                ProductName = p.ProductName,
                                UnitsInStock = p.UnitsInStock
                            };
                           return result.ToList();

            }
        }
    }
}
