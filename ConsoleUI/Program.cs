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

            //foreach (var item in productManager.GetProductDetail())
            //{
            //    Console.WriteLine("{0}----{1}----{2}",item.ProductId,item.ProductName,item.CategoryName);
            //}
            var result = productManager.GetAll().Data;
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }

        }
    }
}
