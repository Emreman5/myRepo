using Core.Utilities.Results;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IResult Add(Category category);
    }
}
