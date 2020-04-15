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
        public Product Parse(ProductInputViewModel model)
        {
            var _model = new Product
            {
                Id = model.ProductId,
                ProductName = model.ProductName,
                Description = model.Description,
                UnitPrice = model.UnitPrice,
                CategoryID = model.CategoryID,
                //ProductFileId = model.ProductFileId,
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
             //   ProductFileId = model.ProductFileId,
                UnitPrice = model.UnitPrice,
                CategoryID = model.CategoryID,
                DateAdded = model.DateAdded,
                DateModified = model.DateModified,
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
                DateAdded = model.DateAdded,
                Description = model.Description,
                DateModified = model.DateModified,
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
                UserId = model.UserId,
                UserName = model.UserName,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                TotalPrice = model.TotalPrice,
                Address = model.Address,
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
                UserId = model.UserId,
                UserName = model.UserName,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                TotalPrice = model.TotalPrice,
                Address = model.Address,
                DateAdded = model.DateAdded,
                DeliveryDate = model.DeliveryDate
            };

            return _model;
        }

        //public ProductFile Parse(ProductFileInputViewModel model)
        //{
        //    var _model = new ProductFile
        //    {
        //        Id = model.ProductFileId,
        //        FileName = model.FileName,
        //        FileUniqueName = model.FileUniqueName,
        //        Ext = model.Ext,
        //        ProductUrl = model.ProductUrl,
        //        ProductUrlUniqueName = model.ProductUrlUniqueName,
        //        DateAdded = DateTime.Now,
        //    };
        //    return _model;
        //}

        public ProductFile Parse(ProductFileInputViewModel model, int productId)
        {
            var _model = new ProductFile
            {
                 Id = model.ProductFileId,
                DateAdded = DateTime.UtcNow,
                Ext = model.Ext,
                ProductUrl = model.ProductUrl,
                ProductUrlUniqueName = model.ProductUrlUniqueName,
                FileName = model.FileName,
                FileUniqueName = model.FileUniqueName,
                ProductId = productId
            };

            return _model;
        }
        public ProductFileOutputViewModel Create(ProductFile model)
        {
            var _model = new ProductFileOutputViewModel
            {
                ProductFileId = model.Id,
                FileName = model.FileName,
                FileUniqueName = model.FileUniqueName,
                Ext = model.Ext,
                ProductUrl = model.ProductUrl,
                ProductUrlUniqueName = model.ProductUrlUniqueName,
                DateAdded = DateTime.Now,
            };

            return _model;
        }

        //public ProductFileOutputViewModel Create(ProductFile model)
        //{
        //    var _model = new ProductFileOutputViewModel
        //    {
        //        ProductFileId = model.Id,
        //        FileName = model.FileName,
        //        FileUniqueName = model.FileUniqueName,
        //        Ext = model.Ext,
        //        ProductUrl = model.ProductUrl,
        //        ProductUrlUniqueName = model.ProductUrlUniqueName,
        //        DateAdded = DateTime.Now,
        //    };
        //    return _model;
        //}

    }
}
