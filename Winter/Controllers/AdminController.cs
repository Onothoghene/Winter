using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Winter.Helpers;
using Winter.ViewModels;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;

namespace Winter.Controllers
{
    public class AdminController : Controller
    {
        public readonly HttpClientLogic _httpClientLogic;
        HttpClientHelper _httpClientHelper = new HttpClientHelper();

        public AdminController()
        {
            _httpClientLogic = new HttpClientLogic();
        }

        public async Task<IActionResult> Index()
        {
            var response = await GetOverView();
            return View(response);
        }

        #region Category Type

        [Route("category/types")]
        public async Task<IActionResult> CategoryTypes(int Id)
        {
            var model = new CategoryTypeInputViewModel()
            {
                CategoryType = await GetCategoryTypeList(),
            };

            if (Id == 0)
                return View(model);
            else
            {
                model = await GetCategoryTypeById(Id);
                model.CategoryType = await GetCategoryTypeList();
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CategoryTypeDelete(int Id)
        {
            try
            {
                HttpClient client = _httpClientHelper.Initial();
                HttpResponseMessage response = client.DeleteAsync($"api/CategoryType/{Id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string stringJWT = await response.Content.ReadAsStringAsync();
                    var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                    TempData["Successful"] = "Deleted Successfully";
                    return RedirectToAction("CategoryTypes", "Admin");
                }
                else
                {
                    string stringJWT = await response.Content.ReadAsStringAsync();
                    var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                    ViewBag.Failed = "An Error Occurred, try again sometime";
                    return RedirectToAction("CategoryTypes", "Admin");
                }
            }
            catch (Exception)
            {
                ViewBag.Failed = "Try again sometime";
                return RedirectToAction("Index", "Admin");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditCategoryType(CategoryTypeInputViewModel model)
        {
            try
            {
                HttpClient client = _httpClientHelper.Initial();
                string stringData = JsonConvert.SerializeObject(model);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                if (model.Id == 0)
                {
                    HttpResponseMessage response = client.PostAsync("api/CategoryType", contentData).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        ViewBag.Message = jwt;
                        TempData["Successful"] = "Successfully Added";
                        return RedirectToAction("CategoryTypes", new { model });
                    }
                    else
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        ViewBag.Failed = "Couldn't Create";
                        return RedirectToAction("CategoryTypes", new { model });
                    }
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync("api/CategoryType", contentData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<bool>(data);
                        TempData["Successful"] = "Updated Successfully";
                        return RedirectToAction("CategoryTypes", new { model });
                    }
                    else
                    {
                        ViewBag.Failed = ViewBag.Failed = "Couldn't Update"; ;
                        model = await GetCategoryTypeById(model.Id);
                        return RedirectToAction("CategoryTypes", new { model });
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Failed = "An Error Occurred";
                return RedirectToAction("CategoryTypes", new { model });
                throw;
            }
        }

        #endregion

        #region Category

        [Route("shop/category")]
        public async Task<IActionResult> Category(int Id)
        {
            var model = new CategoryInputViewModel()
            {
                Category = await GetCategoryList(),
                CategoryTypes = new SelectList(await GetCategoryTypeList(), "Id", "Name"),
        };

            if (Id == 0)
                return View(model);
            else
            {
                model = await GetCategoryById(Id);
                model.Category = await GetCategoryList();
                model.CategoryTypes = new SelectList(await GetCategoryTypeList(), "Id", "Name");
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult CategoryDelete(int Id)
        {
            try
            {
                HttpClient client = _httpClientHelper.Initial();
                HttpResponseMessage response = client.DeleteAsync($"api/Category/{Id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string stringJWT = response.Content.ReadAsStringAsync().Result;
                    var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                    TempData["Successful"] = "Deleted Successfully";
                    return RedirectToAction("Category", "Admin");
                }
                else
                {
                    string stringJWT = response.Content.ReadAsStringAsync().Result;
                    var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                    ViewBag.Failed = "An Error Occurred, try again sometime";
                    return RedirectToAction("Category", "Admin");
                }
            }
            catch (Exception)
            {
                ViewBag.Failed = "Try again sometime";
                return RedirectToAction("Index", "Admin");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditCategory(CategoryInputViewModel model)
        {
            try
            {
                HttpClient client = _httpClientHelper.Initial();
                string stringData = JsonConvert.SerializeObject(model);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                if (model.Id == 0)
                {
                    HttpResponseMessage response = client.PostAsync("api/Category", contentData).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        ViewBag.Message = jwt;
                        TempData["Successful"] = "Successfully Added";
                        return RedirectToAction("Category", new { model });
                    }
                    else
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        ViewBag.Failed = "Couldn't Create";
                        return RedirectToAction("Category", new { model });
                    }
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync("api/Category", contentData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<bool>(data);
                        TempData["Successful"] = "Updated Successfully";
                        return RedirectToAction("Category", new { model });
                    }
                    else
                    {
                        ViewBag.Failed = ViewBag.Failed = "Couldn't Update"; ;
                        model = await GetCategoryById(model.Id);
                        return RedirectToAction("Category", new { model });
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Failed = "An Error Occurred";
                return RedirectToAction("Category", new { model });
                throw;
            }
        }

        #endregion

        #region Sub-Category

        [Route("sub-category")]
        public async Task<IActionResult> SubCategory(int Id)
        {
            var model = new SubCategoryInputViewModel()
            {
                SubCategory = await GetSubCategoryList(),
                Categories = new SelectList(await GetCategoryList(), "Id", "CategoryName"),
            };

            if (Id == 0)
                return View(model);
            else
            {
                model = await GetSubCategoryById(Id);
                model.SubCategory = await GetSubCategoryList();
                model.Categories = new SelectList(await GetCategoryList(), "Id", "CategoryName");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditSubCategory(SubCategoryInputViewModel model)
        {
            try
            {
                HttpClient client = _httpClientHelper.Initial();
                string stringData = JsonConvert.SerializeObject(model);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                if (model.Id == 0)
                {
                    HttpResponseMessage response = client.PostAsync("api/SubCategory", contentData).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        ViewBag.Message = jwt;
                        TempData["Successful"] = "Successfully Added";
                        return RedirectToAction("SubCategory", new { model });
                    }
                    else
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        ViewBag.Failed = "Couldn't Create";
                        return RedirectToAction("SubCategory", new { model });
                    }
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync("api/SubCategory", contentData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<bool>(data);
                        TempData["Successful"] = "Updated Successfully";
                        return RedirectToAction("SubCategory", new { model });
                    }
                    else
                    {
                        ViewBag.Failed = ViewBag.Failed = "Couldn't Update"; ;
                        model = await GetSubCategoryById(model.Id);
                        return RedirectToAction("SubCategory", new { model });
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Failed = "An Error Occurred";
                return RedirectToAction("SubCategory", new { model });
                throw;
            }
        }

        [HttpPost]
        public IActionResult SubCategoryDelete(int Id)
        {
            try
            {
                HttpClient client = _httpClientHelper.Initial();
                HttpResponseMessage response = client.DeleteAsync($"api/SubCategory/{Id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string stringJWT = response.Content.ReadAsStringAsync().Result;
                    var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                    TempData["Successful"] = "Deleted Successfully";
                    return RedirectToAction("SubCategory", "Admin");
                }
                else
                {
                    string stringJWT = response.Content.ReadAsStringAsync().Result;
                    var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                    ViewBag.Failed = "An Error Occurred, try again sometime";
                    return RedirectToAction("SubCategory", "Admin");
                }
            }
            catch (Exception)
            {
                ViewBag.Failed = "Try again sometime";
                return RedirectToAction("Index", "Admin");
                throw;
            }
        }

        #endregion

        #region Brand

        [Route("brand")]
        public async Task<IActionResult> Brand(int Id)
        {
            var model = new BrandInputViewModel()
            {
                Brand = await GetBrandList(),
            };

            if (Id == 0)
                return View(model);
            else
            {
                model = await GetBrandById(Id);
                model.Brand = await GetBrandList();
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditBrand(BrandInputViewModel model)
        {
            try
            {
                HttpClient client = _httpClientHelper.Initial();
                string stringData = JsonConvert.SerializeObject(model);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                if (model.Id == 0)
                {
                    HttpResponseMessage response = client.PostAsync("api/Brand", contentData).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        ViewBag.Message = jwt;
                        TempData["Successful"] = "Successfully Added";
                        return RedirectToAction("Brand", new { model });
                    }
                    else
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        ViewBag.Failed = "Couldn't Create";
                        return RedirectToAction("Brand", new { model });
                    }
                }
                else
                {
                    HttpResponseMessage response = client.PutAsync("api/Brand", contentData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<bool>(data);
                        TempData["Successful"] = "Updated Successfully";
                        return RedirectToAction("Brand", new { model });
                    }
                    else
                    {
                        ViewBag.Failed = ViewBag.Failed = "Couldn't Update"; ;
                        model = await GetBrandById(model.Id);
                        return RedirectToAction("Brand", new { model });
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Failed = "An Error Occurred";
                return RedirectToAction("Brand", new { model });
                throw;
            }
        }

        [HttpPost]
        public IActionResult BrandDelete(int Id)
        {
            try
            {
                HttpClient client = _httpClientHelper.Initial();
                HttpResponseMessage response = client.DeleteAsync($"api/Brand/{Id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string stringJWT = response.Content.ReadAsStringAsync().Result;
                    var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                    TempData["Successful"] = "Deleted Successfully";
                    return RedirectToAction("Brand", "Admin");
                }
                else
                {
                    string stringJWT = response.Content.ReadAsStringAsync().Result;
                    var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                    ViewBag.Failed = "An Error Occurred, try again sometime";
                    return RedirectToAction("Brand", "Admin");
                }
            }
            catch (Exception)
            {
                ViewBag.Failed = "Try again sometime";
                return RedirectToAction("Index", "Admin");
                throw;
            }
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> UserDelete(int Id)
        {
            var response = await DeleteUser(Id);
            return View(response);
        }

        //public IActionResult AddProduct()
        //{
        //    ProductInputViewModel productInput = new ProductInputViewModel();
        //    _product.ConfigureInputViewModelForDropDown(productInput);

        //    return View(productInput);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddProduct(ProductInputViewModel model)
        //{
        //    try
        //    {
        //        List<ProductFileInputViewModel> fileInputs = new List<ProductFileInputViewModel>();

        //        string uploadPath = Environment.CurrentDirectory + "\\uploads";
        //        bool dirExists = Directory.Exists(uploadPath);
        //        if (!dirExists)
        //            Directory.CreateDirectory(uploadPath);
        //        foreach (var file in model.Files)
        //        {
        //            ProductFileInputViewModel fileInput = new ProductFileInputViewModel();

        //            if (file != null && file.Length > 0)
        //            {
        //                var fileExt = GetFileExtensionFromFileName(file.FileName);

        //                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
        //                var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

        //                using (var fileStream = new FileStream(uploadPathWithfileName, FileMode.Create))
        //                {
        //                    await file.CopyToAsync(fileStream);
        //                    fileInput.FileUniqueName = fileName;
        //                    fileInput.FileName = file.FileName;
        //                    fileInput.ProductUrl = uploadPath + file.FileName;
        //                    fileInput.Ext = fileExt;
        //                }

        //                fileInputs.Add(fileInput);
        //            }
        //        }

        //        model.ProductFile = new List<ProductFileInputViewModel>();
        //        //model.ProductFile.AddRange(fileInputs);
        //        var data = Mapper.Map<ProductInputViewModel, Product>(model);
        //        var response = await Task.Run(() => _product.AddProduct(data, fileInputs));

        //        TempData["Message"] = "Added Successful";
        //        return RedirectToAction("Index", "Admin");


        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Message"] = "Not Added";
        //        _product.ConfigureInputViewModelForDropDown(model);
        //        return View(model);
        //        throw;
        //    }
        //    //return View(model);

        //}



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

        //public IActionResult Product()
        //{
        //    var categories = _product.GetProducts();

        //    return View(categories);
        //}

        //public IActionResult Product_Details(int Id)
        //{
        //    //if (Id <= 0)
        //    //{
        //    //    return RedirectToAction("Index");
        //    //}

        //    //var productdetails = _product.GetProductById(Id);

        //    //var generalView = new GeneralViewModel
        //    //{
        //    //    ProductViewModel = productdetails,
        //    //};



        //    //return View(generalView);

        //    return View();
        //}

        //public IActionResult UpdateProduct(int Id)
        //{
        //    var productOutput = _product.GetProductById(Id);

        //    ProductEditViewModel productEdit = new ProductEditViewModel
        //    {
        //        ProductId = productOutput.ProductId,
        //        ProductName = productOutput.ProductName,
        //        CategoryID = productOutput.CategoryID,
        //        Description = productOutput.Description,
        //        UnitPrice = productOutput.UnitPrice,
        //        ProductFile = productOutput.ProductFile,
        //        //DateModified = DateTime.Now,
        //    };
        //    _product.ConfigureEditViewModelForDropDown(productEdit);

        //    return View(productEdit);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UpdateProduct(ProductEditViewModel model)
        //{
        //    try
        //    {
        //        List<ProductFileInputViewModel> fileInputs = new List<ProductFileInputViewModel>();

        //        string uploadPath = Environment.CurrentDirectory + "\\uploads";
        //        bool dirExists = Directory.Exists(uploadPath);
        //        if (!dirExists)
        //            Directory.CreateDirectory(uploadPath);
        //        foreach (var file in model.Files)
        //        {
        //            ProductFileInputViewModel fileInput = new ProductFileInputViewModel();

        //            if (file != null && file.Length > 0)
        //            {
        //                var fileExt = GetFileExtensionFromFileName(file.FileName);

        //                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
        //                var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

        //                using (var fileStream = new FileStream(uploadPathWithfileName, FileMode.Create))
        //                {
        //                    await file.CopyToAsync(fileStream);
        //                    fileInput.FileUniqueName = fileName;
        //                    fileInput.FileName = file.FileName;
        //                    fileInput.ProductUrl = uploadPath + file.FileName;
        //                    fileInput.Ext = fileExt;
        //                }

        //                fileInputs.Add(fileInput);
        //            }
        //        }

        //        model.ProductFile = new List<ProductFileInputViewModel>();
        //        var data = Mapper.Map<ProductEditViewModel, Product>(model);
        //        var response = await Task.Run(() => _product.AddProduct(data, fileInputs));

        //        TempData["Message"] = "Updated Successfully";
        //        return RedirectToAction("Index", "Admin");


        //    }
        //    catch (Exception ex)
        //    {
        //        _product.ConfigureEditViewModelForDropDown(model);
        //        TempData["Message"] = "Not Updated";
        //        return View(model);
        //        throw;
        //    }

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

        //[HttpDelete]
        //public IActionResult DeleteProduct(int Id)
        //{
        //    _product.DeleteProduct(Id);
        //    TempData["Message"] = "Deleted Successfully";
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Orders()
        //{
        //    var orders = _order.GetOrders();

        //    return View(orders);
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


        //public static string GetFileExtensionFromFileName(string fileName)
        //{
        //    string fileExtension = "";
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(fileName) && fileName.Contains('.'))
        //        {
        //            var splittedFileArray = fileName.Split('.');
        //            fileExtension = splittedFileArray[splittedFileArray.Length - 1];
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return fileExtension;
        //}

        public ActionResult DownloadDocument(string Filename)
        {
            //string filepath = _env.WebRootPath + "\\PDF files/" + filename;

            //string filepath = AppDomain.CurrentDomain.BaseDirectory + "PDF files";

            //string filepath = Environment.CurrentDirectory + "\\PDF files/" + filename;
            string uploadPath = Environment.CurrentDirectory + "\\uploads/" + Filename;

            var fileStream = new FileStream(uploadPath,
                                    FileMode.Open,
                                    FileAccess.Read
                                  );
            var fsResult = new FileStreamResult(fileStream, "image/jpeg" /*"image/png"*/);
            return fsResult;
        }

        public async Task<GeneralViewModel> GetOverView()
        {
            string endpoint = $"api/Admin/overview";
            GeneralViewModel response = await _httpClientLogic.GetById<GeneralViewModel>(endpoint);
            return response;
        }

        public async Task<CategoryInputViewModel> GetCategoryById(int categoryId)
        {
            string endpoint = $"api/Category/{categoryId}";
            var response = await _httpClientLogic.GetById<CategoryInputViewModel>(endpoint);
            return response;
        }

        public async Task<IEnumerable<CategoryOutputViewModel>> GetCategoryList()
        {
            string endpoint = $"api/Category";
            var response = await _httpClientLogic.GetList<CategoryOutputViewModel>(endpoint);
            return response;
        }

        public async Task<CategoryTypeInputViewModel> GetCategoryTypeById(int Id)
        {
            string endpoint = $"api/CategoryType/{Id}";
            var response = await _httpClientLogic.GetById<CategoryTypeInputViewModel>(endpoint);
            return response;
        }

        public async Task<IEnumerable<CategoryTypeOutputViewModel>> GetCategoryTypeList()
        {
            string endpoint = $"api/CategoryType";
            var response = await _httpClientLogic.GetList<CategoryTypeOutputViewModel>(endpoint);
            return response;
        }

        public async Task<SubCategoryInputViewModel> GetSubCategoryById(int Id)
        {
            string endpoint = $"api/SubCategory/{Id}";
            var response = await _httpClientLogic.GetById<SubCategoryInputViewModel>(endpoint);
            return response;
        }

        public async Task<IEnumerable<SubCategoryOutputViewModel>> GetSubCategoryList()
        {
            string endpoint = $"api/SubCategory";
            var response = await _httpClientLogic.GetList<SubCategoryOutputViewModel>(endpoint);
            return response;
        }

        public async Task<bool> DeleteUser(int Id)
        {
            string endpoint = $"api/User/{Id}";
            var response = await _httpClientLogic.Delete<bool>(endpoint);
            return response;
        }

        public async Task<BrandInputViewModel> GetBrandById(int Id)
        {
            string endpoint = $"api/Brand/{Id}";
            var response = await _httpClientLogic.GetById<BrandInputViewModel>(endpoint);
            return response;
        }

        public async Task<IEnumerable<BrandOutputViewModel>> GetBrandList()
        {
            string endpoint = $"api/Brand";
            var response = await _httpClientLogic.GetList<BrandOutputViewModel>(endpoint);
            return response;
        }

    }
}