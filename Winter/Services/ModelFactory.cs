using Winter.Data;
using Winter.Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace Winter.Services
{
    public class ModelFactory
    {
        //private readonly WinterContext _context;
        public Product Parse(ProductInputViewModel model)
        {
            var _model = new Product
            {
                Id = model.ProductId,
                ProductName = model.ProductName,
                Description = model.Description,
                Ext = model.Ext,
                Url = model.ProductPath,
                UnitPrice = model.UnitPrice,
                CategoryID = model.CategoryID,
                DateAdded = DateTime.Now,
            };
            return _model;
        }
        public ProductOutputViewModel Create(Product model)
        {
            var _model = new ProductOutputViewModel
            {
                ProductId = model.Id,
                ProductName = model.ProductName,
                Description = model.Description,
                Ext = model.Ext,
                ProductPath = model.Url,
                UnitPrice = model.UnitPrice,
                CategoryID = model.CategoryID,
                DateAdded = DateTime.Now,
            };
            return _model;
        }

        public Category Parse(CategoryInputViewModel model)
        {

            Category _model = new Category()
            {
                Id = model.CategoryId,
                CategoryName = model.CategoryName,
                DateAdded = DateTime.Now,
                Description = model.Description,
                DateModified = DateTime.Now,
            };

            return _model;
        }
        public CategoryOutputViewModel Create(Category model)
        {
            CategoryOutputViewModel _model = new CategoryOutputViewModel()
            {
                CategoryId = model.Id,
                CategoryName = model.CategoryName,
                DateAdded = DateTime.Now,
                Description = model.Description,
            };

            return _model;
        }

        public Order Parse(OrderInputViewModel model)
        {

            Order _model = new Order()
            {
                Id = model.OrderId,
                ProductId = model.ProductId,
                CategoryId = model.CategoryId,
                UserName = model.UserName,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                TotalPrice = model.TotalPrice,
                DateAdded = DateTime.Now,
                DeliveryDate = model.DeliveryDate
            };

            return _model;
        }
        public OrderOutputViewModel Create(Order model)
        {
            OrderOutputViewModel _model = new OrderOutputViewModel()
            {
                OrderId = model.Id,
                ProductId = model.ProductId,
                CategoryId = model.CategoryId,
                UserName = model.UserName,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                TotalPrice = model.TotalPrice,
                DateAdded = DateTime.Now,
                DeliveryDate = model.DeliveryDate
            };

            return _model;
        }

        //public void ImageUpload(ProductInputViewModel model)
        //{
        //    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
        //    string extention = Path.GetExtension(model.ImageFile.FileName);
        //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
        //    model.ImagePath = "~/ImageUploads/" + fileName;
        //    fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/ImageUploads/"), fileName);
        //    model.ImageFile.SaveAs(fileName);
        //}

    }
}
