﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Winter.Helpers;
using Winter.ViewModels.Output_Models;

namespace Winter.Controllers
{
    public class HomeController : Controller
    {
        readonly HttpClientLogic _httpClientLogic = new HttpClientLogic();

        public IActionResult Index()
        {
            return View();
        }

        [Route("product/category")]
        public IActionResult Category()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Items()
        {
            return View();
        }

        #region Methods

        //public List<ProductOutputViewModel> GetNewArrivals()
        //{
        //    var products = new List<ProductOutputViewModel>();
        //    HttpClient client = _helper.Initial();
        //    HttpResponseMessage response = client.GetAsync($"api/Products/NewArrivals").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stringData = response.Content.ReadAsStringAsync().Result;
        //        products = JsonConvert.DeserializeObject<List<ProductOutputViewModel>>(stringData);
        //    }
        //    return products;
        //}

        public async Task<List<ProductOutputViewModel>> GetNewArrivals()
        {
            string endpoint = $"api/Products/NewArrivals";
            var products = await _httpClientLogic.GetById<List<ProductOutputViewModel>>(endpoint);
            return products;
            //return await _httpClientLogic.GetList<ProductOutputViewModel>(endpoint)
                
        }

        //public List<ProductOutputViewModel> GetRandomProducts()
        //{
        //    var products = new List<ProductOutputViewModel>();
        //    HttpClient client = _helper.Initial();
        //    HttpResponseMessage response = client.GetAsync($"api/Products/RandomProducts").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stringData = response.Content.ReadAsStringAsync().Result;
        //        products = JsonConvert.DeserializeObject<List<ProductOutputViewModel>>(stringData);
        //    }
        //    return products;
        //}

        public async Task<List<ProductOutputViewModel>> GetRandomProducts()
        {
            string endpoint = $"api/Products/RandomProducts";
            List<ProductOutputViewModel> products = await _httpClientLogic.GetById<List<ProductOutputViewModel>>(endpoint);
            return products;
        }

        #endregion

    }
}