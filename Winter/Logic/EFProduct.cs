using Winter.Data;
using Winter.Services;
using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Winter.Logic
{
    public class EFProduct : IProduct
    {
        private readonly WinterContext _context;
        ModelFactory _modelFactory = new ModelFactory();


        public EFProduct(WinterContext context)
        {
            _context = context;
        }

        public int AddProduct(ProductInputViewModel model)
        {
            var product = _modelFactory.Parse(model);
            _context.Product.Add(product);
            _context.SaveChanges();

            return product.Id;
        }

        public IEnumerable<ProductOutputViewModel> GetProducts()
        {

            var product = _context.Product.Include(x => x.Category)/*.Where(x => x.CategoryID == churchId)*/.ToList();
            var resp = product.Select(x => _modelFactory.Create(x));

            return resp;
        }

        public ProductOutputViewModel GetProductById(int? Id)
        {
            var product = _context.Product.Find(Id);
            var resp = _modelFactory.Create(product);

            return resp;
        }

        public bool UpdateProduct(ProductEditViewModel model)
        {
            var product = _context.Product.Find(model.ProductId);

            if (product != null)
            {
                product.ProductName = model.ProductName;
                product.Id = model.ProductId;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.UnitPrice = model.UnitPrice;
                product.Description = model.Description;
                product.CategoryID = model.CategoryID;
                product.DateModified = DateTime.Now;
                _context.SaveChanges();
            }

            return true;
        }

        public bool DeleteProduct(int? Id)
        {
            var product = _context.Product.Find(Id);
            _context.Product.Remove(product);
            _context.SaveChanges();

            return true;
        }

        //public void ConfigureInputViewModelForDropDown(ProductInputViewModel model)
        //{

        //}

        //public void ConfigureEditViewModelForDropDown(ProductInputViewModel model)
        //{

        //}
    }
}
