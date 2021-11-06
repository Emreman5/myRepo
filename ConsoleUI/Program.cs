using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)

        {
            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            EmployeeManager employeeManager = new EmployeeManager(new EFEmployeeDal());
            OrderManager orderManager = new OrderManager(new EFOrderDal());
            ProductManager productManager = new ProductManager(new EFProductDal());
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            NorthwindContext context = new NorthwindContext();

            var result = productManager.GetById(3);
            Console.WriteLine(result.Data.ProductName);
          

        }
        public static bool Equals(int a, int b)
        {
            if (Math.Sqrt(a * b) is float)
            {
                return false;
            }
            return true;
        }
    }
}
