
using Core.DataAccess;
using Core.Entities;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICustomerDal:IEntityRepository<Customer>
    {
    }
}
