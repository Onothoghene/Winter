using Winter.Logic;
using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Winter.ViewModels;
using System.Collections.Generic;
using Winter.Models;
using AutoMapper;

namespace Winter.Controllers
{
    public class AdminController : Controller
    {
        public readonly IProduct _product;
        public readonly ICategory _category;    
        public readonly IOrder _order;
        public readonly IUsers _users;

        public AdminController(IProduct product, ICategory category, IOrder order, IUsers users/*, WinterContext winterContext*/)
        {
            _product = product;
            _category = category;
            _order = order;
            _users = users;
          //  _context = winterContext;
        }

        public IActionResult Index()
        {
            GeneralViewModel viewModel = new GeneralViewModel
            {
                CategoryCount = _category.CountCategory(),
                UserCount = _users.CountUser(),
                ProductCount = _product.CountProduct(),
                OrderCount = _order.CountOrders(),
                CategoryOutputViewModel = _category.GetCategory()
            };
            
            return View(viewModel);
        }

        //public IActionResult CategoryCount()
        //{
        //    CategoryOutputViewModel viewModel = new CategoryOutputViewModel();
        //    viewModel.CategoryCount = _category.CountCategory();
        //    return PartialView(viewModel);
        //}

        public IActionResult Add_Category()
        {
            CategoryInputViewModel categoryInput = new CategoryInputViewModel();
            categoryInput.DateAdded = DateTime.Now;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(CategoryInputViewModel category)
        {
            if (ModelState.IsValid)
            {
                _category.AddCategory(category);
                return RedirectToAction("Index", "Admin");
            }
            return View(category);
        }

        //public IActionResult Category()
        //{
        //    GeneralViewModel viewModel = new GeneralViewModel
        //    {
        //        CategoryOutputViewModel = _category.GetCategory()
        //    };
        //    var categories = _category.GetCategory();

        //    return View(viewModel);
        //}

        public IActionResult Category_Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            var categorydetails = _category.GetCategoryById(Id);

            return View(categorydetails);
        }

        public IActionResult Edit_Category(int? Id)
        {
            var category = _category.GetCategoryById(Id);

            CategoryEditViewModel _model = new CategoryEditViewModel()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
            };
            //_category.ConfigureEditViewModelForDropDown(MemberEdit);

            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(CategoryEditViewModel categoryEdit)
        {
            if (ModelState.IsValid)
            {
                _category.UpdateCategory(categoryEdit);
                return RedirectToAction("Index");
            }

            return View(categoryEdit);
        }

        //public IActionResult Delete_Category(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var deleteCategory = _category.GetCategoryById(Id);

        //    return View(deleteCategory);
        //}

        [HttpPost]
        public IActionResult DeleteCategory(int? Id)
        {
            _category.DeleteCategory(Id);

            return RedirectToAction("Index");
        }

        public IActionResult Add_Product()
        {
            ProductInputViewModel productInput = new ProductInputViewModel();
            _product.ConfigureInputViewModelForDropDown(productInput);
            // productInput.DateAdded = DateTime.Now;

            return View(productInput);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductInputViewModel model)
        {
            try
            {
                List<ProductFileInputViewModel> fileInputs = new List<ProductFileInputViewModel>();

                string uploadPath = AppDomain.CurrentDomain.BaseDirectory + "uploads";
                foreach (var file in model.Files)
                {
                    ProductFileInputViewModel fileInput = new ProductFileInputViewModel();

                    if (file != null && file.Length > 0)
                    {

                        var fileExt = GetFileExtensionFromFileName(file.FileName);

                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

                        using (var fileStream = new FileStream(uploadPathWithfileName, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            fileInput.FileUniqueName = fileName;
                            fileInput.FileName = file.FileName;
                            fileInput.Ext = fileExt;
                        }

                        fileInputs.Add(fileInput);
                    }
                }

                model.ProductFile = new List<ProductFileInputViewModel>();
                //model.RegistrationFiles.AddRange(fileInputs);
                var data = Mapper.Map<ProductInputViewModel, Product>(model);
                var response = await Task.Run(() => _product.AddProduct(data, fileInputs));

                        return RedirectToAction("Admin", "Index");


            }
            catch (Exception ex)
            {
                return View(model);
                throw;
            }
            //return View(model);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddProduct(ProductInputViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _product.AddProduct(model);
        //        return RedirectToAction("Index");
        //    }
        //    model.Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName");
        //    return View(model);
        //}

        public IActionResult Product()
        {
            var categories = _product.GetProducts();

            return View(categories);
        }

        public IActionResult Product_Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            var productdetails = _product.GetProductById(Id);

            return View(productdetails);
        }

        //public IActionResult Update_Product(int? Id)
        //{
        //    var productOutput = _product.GetProductById(Id);

        //    ProductEditViewModel productEdit = new ProductEditViewModel
        //    {
        //        ProductId = productOutput.ProductId,
        //        ProductName = productOutput.ProductName,
        //        CategoryID = productOutput.CategoryID,
        //        Description = productOutput.Description,
        //        UnitPrice = productOutput.UnitPrice,
        //        TotalPrice = productOutput.TotalPrice,
        //        ProductPath = productOutput.ProductPath,
        //        Ext = productOutput.Ext,
        //        //FileName = productOutput.FileName,
        //        //DateModified = productOutput.DateModified,

        //        Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName"),
        //};
           
        //    return View(productEdit);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult UpdateProduct(ProductEditViewModel productEdit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //       // SaveImageToFolderAndPathToDb(member);
        //        _product.UpdateProduct(productEdit);
        //        return RedirectToAction("Index");
        //    }
        //    productEdit.Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName");

        //    return View(productEdit);
        //}

        [HttpPost]
        public IActionResult DeleteProduct(int? Id)
        {
            _product.DeleteProduct(Id);

            return RedirectToAction("Index");
        }

        public IActionResult Orders()
        {
            var orders = _order.GetOrders();

            return View(orders);
        }

        //public IActionResult Upload()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Upload(ProductInputViewModel model)
        //{
        //    try
        //    {
        //        var fileInput = new Product();

        //        if (ModelState.IsValid)
        //        {
        //            List<Product> products = new List<Product>();

        //            var path = CreateFolder();
        //            if (model.Files != null)
        //            {
        //                if (model.Files.Count() > 0)
        //                {
        //                    foreach (var file in model.Files)
        //                    {
        //                        fileInput = new Product();
        //                        if (file != null && file.Length > 0)
        //                        {
        //                            var fileExt = GetFileExtensionFromFileName(file.FileName);
        //                            var filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
        //                            var uploadPathWithfileName = Path.Combine(path, filename);

        //                            using (var fileStream = new FileStream(uploadPathWithfileName, FileMode.Create))
        //                            {
        //                                await file.CopyToAsync(fileStream);
        //                                fileInput.ProductName = filename;
        //                                fileInput.Url = path;
        //                                fileInput.Ext = fileExt;
        //                            }
        //                            products.Add(fileInput);
        //                        }
        //                    }
        //                    _context.Product.AddRange(products);
        //                    _context.SaveChanges();

        //                    TempData["Message"] = "Record Inserted";
        //                    TempData["Color"] = "green";

        //                    return RedirectToAction("");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        TempData["Message"] = "Record not Inserted";
        //        TempData["Color"] = "red";
        //        throw;
        //    }

        //    return View(model);
        //}

        public IActionResult UserList()
        {
            var users = _users.GetUsers();

            return View(users);
        }

        public static string GetFileExtensionFromFileName(string fileName)
        {
            string fileExtension = "";
            try
            {
                if (!string.IsNullOrEmpty(fileName) && fileName.Contains('.'))
                {
                    var splittedFileArray = fileName.Split('.');
                    fileExtension = splittedFileArray[splittedFileArray.Length - 1];
                }
            }
            catch (Exception)
            {
            }
            return fileExtension;
        }

        public static string CreateFolder()
        {
            string path = Environment.CurrentDirectory;
            string foldername = "\\Product Images/";
            string folderpath = path + foldername;
            try
            {
                bool dirExists = Directory.Exists(folderpath);
                if (!dirExists)
                    Directory.CreateDirectory(folderpath);
            }
            catch (Exception) { }
            return folderpath;
        }

    }
} 