using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.BusinessAspect.Autofac;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           var result= BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIsNameOk(product.ProductName),
                IsMaxCategoryExceed());
           if (result!=null)
           {
               return result;
           }
           _productDal.Add(product);
           return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new DataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == id),Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == id), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max),Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDTo>> GetProductDetail()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<ProductDetailDTo>>(_productDal.GetProductDetails(),Messages.MaintenanceTime);
            }
            return new DataResult<List<ProductDetailDTo>>(_productDal.GetProductDetails(),true,Messages.ProductsListed);
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            if (_productDal.GetAll(p=>p.CategoryId==categoryId).Count>=10)
                return new ErrorResult();
            return new SuccessResult();
        }

        private IResult CheckIsNameOk(string productName)
        {
            if (_productDal.GetAll(p=>p.ProductName==productName).Any())
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult IsMaxCategoryExceed()
        {
            var result = _categoryService.GetAll().Data.Count;
            if (result>15)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        
        }

}

