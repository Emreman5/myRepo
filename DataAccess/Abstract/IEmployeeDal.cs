using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
   public interface IEmployeeDal:IEntityRepository<Employee>
    {
    }
}
