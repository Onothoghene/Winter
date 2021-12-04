using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using API.Winter.Logic.Interfaces;
using API.Winter.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace API.Winter.Logic
{
    public class EFProduct : IProduct
    {
        private readonly WinterContext _context;
        readonly IMapper _mapper;
        //readonly ModelFactory _modelFactory = new ModelFactory();
        //ProductFileInputViewModel filemodel = new ProductFileInputViewModel();

        public EFProduct(WinterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public bool AddProduct(ProductIM model)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            var prodct = _modelFactory.Parse(model);
        //            _context.Product.Add(prodct);
        //            int bit = _context.SaveChanges();
        //            ts.Complete();

        //            if (bit > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public bool AddProduct(ProductIM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //var product = _modelFactory.Parse(model);
                    var product = _mapper.Map<Product>(model);
                    _context.Product.Add(product);
                    int bit = _context.SaveChanges();
                    ts.Complete();

                    if (bit > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public bool AddProductFile(ProductIM model)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            var product = _modelFactory.Parse(model);
        //            _context.ProductFile.Add(prodct);
        //            int bit = _context.SaveChanges();
        //            ts.Complete();

        //            if (bit > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public IEnumerable<ProductOM> GetProducts()
        {
            try
            {
                var product = _context.Product.Include(x => x.Category)
                                                                   .Include(x => x.Files)
                                                                   .ToList();
                //var resp = product.Select(x => _modelFactory.Create2(x));
                var resp = _mapper.Map<IEnumerable<ProductOM>>(product);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProductOM GetProductById(int Id)
        {
            try
            {
                var product = _context.Product.Where(a => a.Id == Id)
                                                                        .Include(x => x.Category)
                                                                       .Include(x => x.Files)
                                                                       .FirstOrDefault();

                //var resp = _modelFactory.Create2(product);
                var resp = _mapper.Map<ProductOM>(product);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateProduct(ProductEM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var product = _context.Product.Find(model.ProductId);

                    if (product != null)
                    {
                        if (!string.IsNullOrEmpty(model.ProductName))
                            product.ProductName = model.ProductName;

                        if (!string.IsNullOrEmpty(model.ProductName))
                            product.Description = model.Description;

                        if (model.UnitPrice > 0)
                            product.UnitPrice = model.UnitPrice;

                        if (model.CategoryId > 0)
                            product.CategoryId = model.CategoryId;

                        product.DateModified = DateTime.Now;

                        _context.SaveChanges();
                        ts.Complete();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteProduct(int Id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var product = _context.Product.Find(Id);
                    if (product != null)
                    {
                        _context.Product.Remove(product);
                        _context.SaveChanges();
                        ts.Complete();
                        return true;

                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CountProduct()
        {
            try
            {
                var count = _context.Product.ToList().Count();
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ProductOM> GetNewArrivals()
        {
            try
            {
                var products = _context.Product.OrderByDescending(b => b.DateAdded)
                                                                    .Take(6)
                                                                   .Include(x => x.Category)
                                                                   .Include(x => x.Files)
                                                                   .ToList();
                //var resp = products.Select(x => _modelFactory.Create2(x));
                var resp = _mapper.Map<IEnumerable<ProductOM>>(products);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IEnumerable<ProductOM> GetRandomProducts()
        {
            try
            {
                var rand = new Random();
                var products = _context.Product.Include(d => d.Brand).Include(t => t.Files).ToList();

                var chosenItems = new List<Product>();
                var productstoGet = 5;

                for (int i = 0; i < productstoGet; i++)
                {
                    int index = rand.Next(products.Count());
                    chosenItems.Add(products[i]);
                }

                //var resp = chosenItems.Select(x => _modelFactory.Create2(x));
                var resp = _mapper.Map<IEnumerable<ProductOM>>(chosenItems);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
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

        //public void ConfigureInputViewModelForDropDown(ProductInputViewModel model)
        //{
        //    try
        //    {
        //        var categoryList = _context.Category.ToList();
        //        //model.Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName");
        //        model.Categories = new SelectList(categoryList.Select(f => _modelFactory.CreateLite(f)));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public void ConfigureEditViewModelForDropDown(ProductEditViewModel model)
        //{
        //    try
        //    {
        //        var categoryList = _context.Category.ToList();
        //        //model.Categories = new SelectList(_context.Category.ToList(), "Id", "CategoryName");
        //        model.Categories = new SelectList(categoryList.Select(f => _modelFactory.CreateLite(f)));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

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
