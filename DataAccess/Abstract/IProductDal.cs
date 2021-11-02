using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
  public  interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDTo> GetProductDetails();
    }
}
