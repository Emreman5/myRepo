using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            this._customerDal = customerDal;
        }

        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            return _customerDal.Get(filter);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
