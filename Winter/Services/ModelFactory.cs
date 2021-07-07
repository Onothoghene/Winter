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
        #region WishList

        public Wish Parse(WishIM model)
        {
            var _model = new Wish
            {
                ProductId = model.ProductId,
                UserId = model.UserId,
                DateAdded = DateTime.Now,
            };
            return _model;
        }

        public WishOM Create(Wish model)
        {
            var _model = new WishOM
            {
                ProductId = model.ProductId,
                ProductName = model.Product.ProductName,
                UserId = model.UserId,
                UserName = Create(model.User.FullName, model.User.LastName),
                DateAdded = model.DateAdded,
            };
            return _model;
        }

        #endregion

        #region Product

        public Product Parse(ProductInputViewModel model)
        {
            var _model = new Product
            {
                Id = model.ProductId,
                ProductName = model.ProductName,
                Description = model.Description,
                UnitPrice = model.UnitPrice,
                //CategoryID = model.CategoryID,
                //ProductFileId = model.ProductFileId,
                DateAdded = DateTime.Now,
            };
            return _model;
        }

        public ProductOutputViewModel Create(Product model)
        {
            ProductOutputViewModel _model = new ProductOutputViewModel
            {
                ProductId = model.Id,
                ProductName = model.ProductName,
                Category = model.Category.CategoryName,
                Description = model.Description,
                UnitPrice = model.UnitPrice,
                // CategoryID = model.CategoryID,
                DateAdded = model.DateAdded,
                DateModified = model.DateModified,
            };

            if (model.ProductFile != null)
            {
                if (model.ProductFile.Count > 0)
                {
                    _model.ProductFile = model.ProductFile.Select(x => Create(x)).ToList();
                }
            }

            return _model;
        }

        #endregion

        #region Category

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

        #endregion

        #region Order

        public OrderRequest Parse(OrderInputViewModel model)
        {

            OrderRequest _model = new OrderRequest()
            {
                Id = model.OrderId,
                ProductId = model.ProductId,
                AddedBy = model.UserId,
                //UnitPrice = model.UnitPrice,
                //Quantity = model.Quantity,
                //TotalPrice = model.TotalPrice,
                //Address = model.Address,
                //DateAdded = DateTime.Now,
                //DeliveryDate = model.DeliveryDate
            };

            return _model;
        }

        public OrderOutputViewModel Create(OrderRequest model)
        {
            OrderOutputViewModel _model = new OrderOutputViewModel()
            {
                OrderId = model.Id,
                ProductId = model.ProductId,
                UserId = model.AddedBy,
                UserName = Create(model.AddedByNavigation.FullName, model.AddedByNavigation.LastName),
                ProductName = model.Product.ProductName,
                //UnitPrice = model.UnitPrice,
                //Quantity = model.Quantity,
                //TotalPrice = model.TotalPrice,
                //Address = model.Address,
                //DateAdded = model.DateAdded,
                //DeliveryDate = model.DeliveryDate
            };

            return _model;
        }

        #endregion


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
        public ProductFileInputViewModel Create(ProductFile model)
        {
            var _model = new ProductFileInputViewModel
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

        #region Methods

        public string Create(string FirstName, string LastName)
        {
            return FirstName + " " + LastName;
        }

        #endregion

    }
}
