﻿//using Winter.Models;
//using Winter.ViewModels.Input_Models;
//using Winter.ViewModels.Output_Models;
//using System;
//using System.Linq;
//using Winter.DTO.Input_Models;
//using Winter.DTO.Output_Models;

//namespace Winter.Services
//{
//    public class ModelFactory
//    {
//        #region WishList

//        public Wish Parse(WishIM model)
//        {
//            var _model = new Wish
//            {
//                ProductId = model.ProductId,
//                //UserId = model.UserId,
//                DateAdded = DateTime.Now,
//            };
//            return _model;
//        }

//        public WishOM Create(Wish model)
//        {
//            var _model = new WishOM
//            {
//                ProductId = model.ProductId,
//                ProductName = model.Product.ProductName,
//                UserId = model.UserId,
//                UserName = Create(model.User.FirstName, model.User.LastName),
//                //DateAdded = model.DateAdded,
//            };
//            return _model;
//        }

//        #endregion

//        #region Product

//        public Product Parse(ProductInputViewModel model)
//        {
//            var _model = new Product
//            {
//                Id = model.ProductId,
//                ProductName = model.ProductName,
//                Description = model.Description,
//                UnitPrice = model.UnitPrice,

//                //CategoryID = model.CategoryID,
//                //ProductFileId = model.ProductFileId,
//                DateAdded = DateTime.Now,
//            };
//            return _model;
//        }

//        public ProductOutputViewModel Create(Product model)
//        {
//            ProductOutputViewModel _model = new ProductOutputViewModel
//            {
//                ProductId = model.Id,
//                ProductName = model.ProductName,
//                Category = model.Category.CategoryName,
//                Description = model.Description,
//                UnitPrice = model.UnitPrice,
//                // CategoryID = model.CategoryID,
//                DateAdded = model.DateAdded,
//                DateModified = model.DateModified,
//            };

//            if (model.Files != null)
//            {
//                if (model.Files.Count > 0)
//                {
//                    _model.ProductFile = model.Files.Select(x => Create(x)).ToList();
//                }
//            }

//            return _model;
//        }

//        public Product Parse(ProductIM model)
//        {
//            var _model = new Product
//            {
//                //Id = model.ProductId,
//                //ProductName = model.ProductName,
//                //Description = model.Description,
//                //UnitPrice = model.UnitPrice,
//                //CategoryID = model.CategoryID,
//                //ProductFileId = model.ProductFileId,
//                DateAdded = DateTime.Now,
//            };
//            return _model;
//        }

//        public ProductOM Create2(Product model)
//        {
//            var _model = new ProductOM
//            {
//                ProductId = model.Id,
//                ProductName = model.ProductName,
//                Category = model.Category.CategoryName,
//                Description = model.Description,
//                UnitPrice = model.UnitPrice,
//                // CategoryID = model.CategoryID,
//                DateAdded = model.DateAdded,
//                DateModified = model.DateModified,
//            };

//            if (model.Files != null)
//            {
//                if (model.Files.Count > 0)
//                {
//                    _model.ProductFile = model.Files.Select(x => Create(x)).ToList();
//                }
//            }

//            return _model;
//        }

//        #endregion

//        #region Category

//        public Category Parse(CategoryInputViewModel model)
//        {

//            Category _model = new Category()
//            {
//                Id = model.CategoryId,
//                CategoryName = model.CategoryName,
//                DateAdded = DateTime.Now,
//                Description = model.Description,
//                DateModified = DateTime.Now,
//            };

//            return _model;
//        }

//        public CategoryOutputViewModel Create(Category model)
//        {
//            CategoryOutputViewModel _model = new CategoryOutputViewModel()
//            {
//                CategoryId = model.Id,
//                CategoryName = model.CategoryName,
//                DateAdded = model.DateAdded,
//                Description = model.Description,
//                DateModified = model.DateModified,
//            };

//            return _model;
//        }

//        public CategoryOMLite CreateLite(Category model)
//        {
//            var _model = new CategoryOMLite()
//            {
//                CategoryId = model.Id,
//                CategoryName = model.CategoryName,
//            };
//            return _model;
//        }

//        #endregion

//        #region Order

//        public OrderRequest Parse(OrderInputViewModel model)
//        {

//            OrderRequest _model = new OrderRequest()
//            {
//                Id = model.OrderId,
//                ProductId = model.ProductId,
//                //AddedBy = model.UserId,
//                //UnitPrice = model.UnitPrice,
//                //Quantity = model.Quantity,
//                //TotalPrice = model.TotalPrice,
//                //Address = model.Address,
//                //DateAdded = DateTime.Now,
//                //DeliveryDate = model.DeliveryDate
//            };

//            return _model;
//        }

//        public OrderOutputViewModel Create(OrderRequest model)
//        {
//            OrderOutputViewModel _model = new OrderOutputViewModel()
//            {
//                OrderId = model.Id,
//                ProductId = model.ProductId,
//                UserId = model.AddedBy,
//                UserName = Create(model.AddedByNavigation.FirstName, model.AddedByNavigation.LastName),
//                ProductName = model.Product.ProductName,
//                //UnitPrice = model.UnitPrice,
//                //Quantity = model.Quantity,
//                //TotalPrice = model.TotalPrice,
//                //Address = model.Address,
//                //DateAdded = model.DateAdded,
//                //DeliveryDate = model.DeliveryDate
//            };

//            return _model;
//        }

//        #endregion

//        #region Users

//        public UserOM Create(UserProfile model)
//        {
//            var _model = new UserOM()
//            {
//                Email = model.Email,
//                FirstName = model.FirstName,
//                LastName = model.LastName,
//                PhoneNumber = model.PhoneNumber,
//                AspNetId = model.AspNetId,
//                Id = model.Id,
//            };

//            return _model;
//        }

//        public UserProfile Parse(UserIM model)
//        {
//            var _model = new UserProfile()
//            {
//                FirstName = model.FirstName,
//                LastName = model.LastName,
//                PhoneNumber = model.PhoneNumber,
//                Email = model.Email,
//                DateAdded = DateTime.Now,
//                AspNetId = model.AspNetId,
//            };
//            return _model;
//        }

//        #endregion

//        #region Cart Item

//        public Cart Parse(CartIM model)
//        {
//            var _model = new Cart
//            {
//                ProductId = model.ProductId,
//                //UserId = model.UserId,
//                DateAdded = DateTime.Now,
//            };
//            //  _model.Quantity = model.Quantity > 0 ? model.Quantity : _model.Quantity++;

//            return _model;
//        }

//        public CartOM Create(Cart model)
//        {
//            var _model = new CartOM
//            {
//                ProductId = model.ProductId,
//                ProductName = model.Product.ProductName,
//                UserId = model.UserId,
//                UserName = Create(model.User.FirstName, model.User.LastName),
//                DateAdded = (DateTime)model.DateAdded,
//                //Quantity = (int)model.Quantity,
//            };
//            return _model;
//        }

//        #endregion

//        //public ProductFile Parse(ProductFileInputViewModel model)
//        //{
//        //    var _model = new ProductFile
//        //    {
//        //        Id = model.ProductFileId,
//        //        FileName = model.FileName,
//        //        FileUniqueName = model.FileUniqueName,
//        //        Ext = model.Ext,
//        //        ProductUrl = model.ProductUrl,
//        //        ProductUrlUniqueName = model.ProductUrlUniqueName,
//        //        DateAdded = DateTime.Now,
//        //    };
//        //    return _model;
//        //}

//        public Files Parse(ProductFileInputViewModel model, int productId)
//        {
//            var _model = new Files
//            {
//                Id = model.ProductFileId,
//                DateAdded = DateTime.UtcNow,
//                Ext = model.Ext,
//                ProductUrl = model.ProductUrl,
//                ProductUrlUniqueName = model.ProductUrlUniqueName,
//                FileName = model.FileName,
//                FileUniqueName = model.FileUniqueName,
//                ProductId = productId
//            };

//            return _model;
//        }

//        public ProductFileInputViewModel Create(Files model)
//        {
//            var _model = new ProductFileInputViewModel
//            {
//                ProductFileId = model.Id,
//                FileName = model.FileName,
//                FileUniqueName = model.FileUniqueName,
//                Ext = model.Ext,
//                ProductUrl = model.ProductUrl,
//                ProductUrlUniqueName = model.ProductUrlUniqueName,
//                DateAdded = DateTime.Now,
//            };

//            return _model;
//        }

//        //public ProductFileOutputViewModel Create(ProductFile model)
//        //{
//        //    var _model = new ProductFileOutputViewModel
//        //    {
//        //        ProductFileId = model.Id,
//        //        FileName = model.FileName,
//        //        FileUniqueName = model.FileUniqueName,
//        //        Ext = model.Ext,
//        //        ProductUrl = model.ProductUrl,
//        //        ProductUrlUniqueName = model.ProductUrlUniqueName,
//        //        DateAdded = DateTime.Now,
//        //    };
//        //    return _model;
//        //}

//        #region Methods

//        public string Create(string FirstName, string LastName)
//        {
//            return FirstName + " " + LastName;
//        }

//        #endregion

//    }
//}
