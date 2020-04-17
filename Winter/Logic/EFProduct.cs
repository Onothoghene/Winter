using Winter.Data;
using Winter.Services;
using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Winter.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Winter.Logic
{
    public class EFProduct : IProduct
    {
        private readonly WinterContext _context;
        ModelFactory _modelFactory = new ModelFactory();
        ProductFileInputViewModel filemodel = new ProductFileInputViewModel();

        public EFProduct(WinterContext context)
        {
            _context = context;
        }

        //public int AddProduct(ProductInputViewModel model)
        //{
        //    FileUpload(filemodel);
        //    var product = _modelFactory.Parse(model);
        //    _context.Product.Add(product);
        //    _context.SaveChanges();

        //    return product.Id;
        //}

        public int AddProduct(Product model, List<ProductFileInputViewModel> productFiles)
        {
            try
            {
                model.DateAdded = DateTime.UtcNow;
                _context.Add(model);

                var res = _context.SaveChanges();

                if (res > 0)
                {
                    if (productFiles.Count > 0)
                    {
                        var regFiles = productFiles.Select(x => _modelFactory.Parse(x, model.Id));

                        _context.AddRange(regFiles);
                    }
                }
                _context.SaveChanges();
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<ProductOutputViewModel> GetProducts()
        {
            var product = _context.Product.Include(x => x.Category)
                                                                    .Include(x => x.ProductFile)
                                                                    .ToList();
            var resp = product.Select(x => _modelFactory.Create(x));

            return resp;
        }

        public ProductOutputViewModel GetProductById(int? Id)
        {
            //var product = _context.Product.Find(Id);
            var product = _context.Product.Include(x => x.Category)
                                                                   .Include(x => x.ProductFile)
                                                                   .Where(a => a.Id == Id).FirstOrDefault();

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

       public  int CountProduct()
        {
            var count = _context.Product.ToList().Count();
            return count;
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

        public void ConfigureInputViewModelForDropDown(ProductInputViewModel model)
        {
            model.Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName");
        }

        public void ConfigureEditViewModelForDropDown(ProductEditViewModel model)
        {
            model.Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName");
        }

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

    }
}
