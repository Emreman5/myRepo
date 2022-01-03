using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;


namespace DataAccess.Abstract
{
  public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDTo> GetProductDetails();
    }
}
