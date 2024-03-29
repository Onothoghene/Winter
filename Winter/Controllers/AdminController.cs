﻿//using Winter.Logic;
//using Winter.ViewModels.Edit_Models;
//using Winter.ViewModels.Input_Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Winter.ViewModels;
//using System.Collections.Generic;
//using Winter.Models;
//using AutoMapper;
//using Winter.ViewModels.Output_Models;
//using Winter.ILogic;

//namespace Winter.Controllers
//{
//    public class AdminController : Controller
//    {
//        public readonly IProduct _product;
//        public readonly ICategory _category;
//        public readonly IOrder _order;
//        public readonly IUsers _users;

//        public AdminController(IProduct product, ICategory category, IOrder order, IUsers users/*, WinterContext winterContext*/)
//        {
//            _product = product;
//            _category = category;
//            _order = order;
//            _users = users;
//            //  _context = winterContext;
//        }

//        //public IActionResult Index()
//        //{
//        //    GeneralViewModel viewModel = new GeneralViewModel
//        //    {
//        //        CategoryCount = _category.CountCategory(),
//        //        UserCount = _users.CountUser(),
//        //        ProductCount = _product.CountProduct(),
//        //        OrderCount = _order.CountOrders(),
//        //        CategoryOutputViewModel = _category.GetCategory(),
//        //        ProductOutputViewModel = _product.GetProducts(),
//        //        OrderOutputViewModel = _order.GetOrders(),
//        //        ApplicationUser = _users.GetUsers(),
//        //    };


//        //    return View(viewModel);
//        //}

//        //public IActionResult CategoryCount()
//        //{
//        //    CategoryOutputViewModel viewModel = new CategoryOutputViewModel();
//        //    viewModel.CategoryCount = _category.CountCategory();
//        //    return PartialView(viewModel);
//        //}

//        public IActionResult Add_Category()
//        {
//            CategoryInputViewModel categoryInput = new CategoryInputViewModel
//            {
//                DateAdded = DateTime.Now
//            };
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult AddCategory(CategoryInputViewModel category)
//        {
//            if (ModelState.IsValid)
//            {
//                _category.AddCategory(category);
//                TempData["Message"] = "Added Successfully";
//                return RedirectToAction("Index", "Admin");
//            }
//            TempData["Message"] = "Not Added";
//            return View(category);
//        }

//        //public IActionResult Category()
//        //{
//        //    GeneralViewModel viewModel = new GeneralViewModel
//        //    {
//        //        CategoryOutputViewModel = _category.GetCategory()
//        //    };
//        //    var categories = _category.GetCategory();

//        //    return View(viewModel);
//        //}

//        public IActionResult CategoryDetails(int Id)
//        {
//            if (Id == null)
//            {
//                return RedirectToAction("Index");
//            }
//            var categorydetails = _category.GetCategoryById(Id);

//            return View(categorydetails);
//        }

//        public IActionResult Edit_Category(int Id)
//        {
//            var category = _category.GetCategoryById(Id);

//            CategoryEditViewModel _model = new CategoryEditViewModel()
//            {
//                CategoryId = category.CategoryId,
//                CategoryName = category.CategoryName,
//                Description = category.Description,
//            };

//            return View(_model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult EditCategory(CategoryEditViewModel categoryEdit)
//        {
//            if (ModelState.IsValid)
//            {
//                _category.UpdateCategory(categoryEdit);
//                TempData["Message"] = "Updated Successfully";
//                return RedirectToAction("Index");
//            }
//            TempData["Message"] = "Not Updated";
//            return View(categoryEdit);
//        }

//        //public IActionResult Delete_Category(int? Id)
//        //{
//        //    if (Id == null)
//        //    {
//        //        return RedirectToAction("Index");
//        //    }
//        //    var deleteCategory = _category.GetCategoryById(Id);

//        //    return View(deleteCategory);
//        //}

//        [HttpPost]
//        public IActionResult DeleteCategory(int Id)
//        {
//            _category.DeleteCategory(Id);

//            TempData["Message"] = "Deleted Successfully";
//            return RedirectToAction("Index");
//        }

//        public IActionResult AddProduct()
//        {
//            ProductInputViewModel productInput = new ProductInputViewModel();
//            _product.ConfigureInputViewModelForDropDown(productInput);

//            return View(productInput);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> AddProduct(ProductInputViewModel model)
//        {
//            try
//            {
//                List<ProductFileInputViewModel> fileInputs = new List<ProductFileInputViewModel>();

//                string uploadPath = Environment.CurrentDirectory + "\\uploads";
//                bool dirExists = Directory.Exists(uploadPath);
//                if (!dirExists)
//                    Directory.CreateDirectory(uploadPath);
//                foreach (var file in model.Files)
//                {
//                    ProductFileInputViewModel fileInput = new ProductFileInputViewModel();

//                    if (file != null && file.Length > 0)
//                    {
//                        var fileExt = GetFileExtensionFromFileName(file.FileName);

//                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
//                        var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

//                        using (var fileStream = new FileStream(uploadPathWithfileName, FileMode.Create))
//                        {
//                            await file.CopyToAsync(fileStream);
//                            fileInput.FileUniqueName = fileName;
//                            fileInput.FileName = file.FileName;
//                            fileInput.ProductUrl = uploadPath + file.FileName;
//                            fileInput.Ext = fileExt;
//                        }

//                        fileInputs.Add(fileInput);
//                    }
//                }

//                model.ProductFile = new List<ProductFileInputViewModel>();
//                //model.ProductFile.AddRange(fileInputs);
//                var data = Mapper.Map<ProductInputViewModel, Product>(model);
//                var response = await Task.Run(() => _product.AddProduct(data, fileInputs));

//                TempData["Message"] = "Added Successful";
//                return RedirectToAction("Index", "Admin");


//            }
//            catch (Exception ex)
//            {
//                TempData["Message"] = "Not Added";
//                _product.ConfigureInputViewModelForDropDown(model);
//                return View(model);
//                throw;
//            }
//            //return View(model);

//        }

//        public ActionResult DownloadDocument(string Filename)
//        {
//            //string filepath = _env.WebRootPath + "\\PDF files/" + filename;

//            //string filepath = AppDomain.CurrentDomain.BaseDirectory + "PDF files";

//            //string filepath = Environment.CurrentDirectory + "\\PDF files/" + filename;
//            string uploadPath = Environment.CurrentDirectory + "\\uploads/" + Filename;

//            var fileStream = new FileStream(uploadPath,
//                                    FileMode.Open,
//                                    FileAccess.Read
//                                  );
//            var fsResult = new FileStreamResult(fileStream, "image/jpeg" /*"image/png"*/);
//            return fsResult;
//        }

//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public IActionResult AddProduct(ProductInputViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        _product.AddProduct(model);
//        //        return RedirectToAction("Index");
//        //    }
//        //    model.Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName");
//        //    return View(model);
//        //}

//        public IActionResult Product()
//        {
//            var categories = _product.GetProducts();

//            return View(categories);
//        }

//        public IActionResult Product_Details(int Id)
//        {
//            //if (Id <= 0)
//            //{
//            //    return RedirectToAction("Index");
//            //}

//            //var productdetails = _product.GetProductById(Id);

//            //var generalView = new GeneralViewModel
//            //{
//            //    ProductViewModel = productdetails,
//            //};



//            //return View(generalView);

//            return View();
//        }

//        public IActionResult UpdateProduct(int Id)
//        {
//            var productOutput = _product.GetProductById(Id);

//            ProductEditViewModel productEdit = new ProductEditViewModel
//            {
//                ProductId = productOutput.ProductId,
//                ProductName = productOutput.ProductName,
//                CategoryID = productOutput.CategoryID,
//                Description = productOutput.Description,
//                UnitPrice = productOutput.UnitPrice,
//                ProductFile = productOutput.ProductFile,
//                //DateModified = DateTime.Now,
//            };
//            _product.ConfigureEditViewModelForDropDown(productEdit);

//            return View(productEdit);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> UpdateProduct(ProductEditViewModel model)
//        {
//            try
//            {
//                List<ProductFileInputViewModel> fileInputs = new List<ProductFileInputViewModel>();

//                string uploadPath = Environment.CurrentDirectory + "\\uploads";
//                bool dirExists = Directory.Exists(uploadPath);
//                if (!dirExists)
//                    Directory.CreateDirectory(uploadPath);
//                foreach (var file in model.Files)
//                {
//                    ProductFileInputViewModel fileInput = new ProductFileInputViewModel();

//                    if (file != null && file.Length > 0)
//                    {
//                        var fileExt = GetFileExtensionFromFileName(file.FileName);

//                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
//                        var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

//                        using (var fileStream = new FileStream(uploadPathWithfileName, FileMode.Create))
//                        {
//                            await file.CopyToAsync(fileStream);
//                            fileInput.FileUniqueName = fileName;
//                            fileInput.FileName = file.FileName;
//                            fileInput.ProductUrl = uploadPath + file.FileName;
//                            fileInput.Ext = fileExt;
//                        }

//                        fileInputs.Add(fileInput);
//                    }
//                }

//                model.ProductFile = new List<ProductFileInputViewModel>();
//                var data = Mapper.Map<ProductEditViewModel, Product>(model);
//                var response = await Task.Run(() => _product.AddProduct(data, fileInputs));

//                TempData["Message"] = "Updated Successfully";
//                return RedirectToAction("Index", "Admin");


//            }
//            catch (Exception ex)
//            {
//                _product.ConfigureEditViewModelForDropDown(model);
//                TempData["Message"] = "Not Updated";
//                return View(model);
//                throw;
//            }

//        }

//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public IActionResult UpdateProduct(ProductEditViewModel productEdit)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //       // SaveImageToFolderAndPathToDb(member);
//        //        _product.UpdateProduct(productEdit);
//        //        return RedirectToAction("Index");
//        //    }
//        //    productEdit.Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName");

//        //    return View(productEdit);
//        //}

//        [HttpDelete]
//        public IActionResult DeleteProduct(int Id)
//        {
//            _product.DeleteProduct(Id);
//            TempData["Message"] = "Deleted Successfully";
//            return RedirectToAction("Index");
//        }

//        public IActionResult Orders()
//        {
//            var orders = _order.GetOrders();

//            return View(orders);
//        }

//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Upload(ProductInputViewModel model)
//        //{
//        //    try
//        //    {
//        //        var fileInput = new Product();

//        //        if (ModelState.IsValid)
//        //        {
//        //            List<Product> products = new List<Product>();

//        //            var path = CreateFolder();
//        //            if (model.Files != null)
//        //            {
//        //                if (model.Files.Count() > 0)
//        //                {
//        //                    foreach (var file in model.Files)
//        //                    {
//        //                        fileInput = new Product();
//        //                        if (file != null && file.Length > 0)
//        //                        {
//        //                            var fileExt = GetFileExtensionFromFileName(file.FileName);
//        //                            var filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
//        //                            var uploadPathWithfileName = Path.Combine(path, filename);

//        //                            using (var fileStream = new FileStream(uploadPathWithfileName, FileMode.Create))
//        //                            {
//        //                                await file.CopyToAsync(fileStream);
//        //                                fileInput.ProductName = filename;
//        //                                fileInput.Url = path;
//        //                                fileInput.Ext = fileExt;
//        //                            }
//        //                            products.Add(fileInput);
//        //                        }
//        //                    }
//        //                    _context.Product.AddRange(products);
//        //                    _context.SaveChanges();

//        //                    TempData["Message"] = "Record Inserted";
//        //                    TempData["Color"] = "green";

//        //                    return RedirectToAction("");
//        //                }
//        //            }
//        //        }
//        //    }
//        //    catch (Exception)
//        //    {
//        //        TempData["Message"] = "Record not Inserted";
//        //        TempData["Color"] = "red";
//        //        throw;
//        //    }

//        //    return View(model);
//        //}

//        //public IActionResult UserList()
//        //{
//        //    var users = _users.GetUsers();

//        //    return View(users);
//        //}

//        public static string GetFileExtensionFromFileName(string fileName)
//        {
//            string fileExtension = "";
//            try
//            {
//                if (!string.IsNullOrEmpty(fileName) && fileName.Contains('.'))
//                {
//                    var splittedFileArray = fileName.Split('.');
//                    fileExtension = splittedFileArray[splittedFileArray.Length - 1];
//                }
//            }
//            catch (Exception)
//            {
//            }
//            return fileExtension;
//        }

//    }
//}