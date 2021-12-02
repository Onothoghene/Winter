using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Winter.Helpers
{
    //public class HttpClientLogic<T> :  IHttpClientLogic<T> where T : class
    public class HttpClientLogic :  IHttpClientLogic
    {
        public HttpClientHelper _helper;
        public IMapper _mapper;

        public async Task<T> Add<T>(T entity, string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.PostAsync(Urlendpoint, contentData).Result;

            if (response.IsSuccessStatusCode)
            {
                string stringJWT = await response.Content.ReadAsStringAsync();
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
            else
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
        }

        public async Task<T> AddRange<T>(IEnumerable<T> entity, string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.PostAsync(Urlendpoint, contentData).Result;

            if (response.IsSuccessStatusCode)
            {
                string stringJWT = await response.Content.ReadAsStringAsync();
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
            else
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
        }

        public async Task<T> Update<T>(T entity, string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.PutAsync(Urlendpoint, contentData).Result;

            if (response.IsSuccessStatusCode)
            {
                string stringJWT = await response.Content.ReadAsStringAsync();
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
            else
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
        }

        public async Task<T> UpdateRange<T>(IEnumerable<T> entity, string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.PutAsync(Urlendpoint, contentData).Result;

            if (response.IsSuccessStatusCode)
            {
                string stringJWT = await response.Content.ReadAsStringAsync();
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
            else
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
        }

        public async Task<T> GetById<T>(T entity, string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.GetAsync(Urlendpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                string stringJWT = await response.Content.ReadAsStringAsync();
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
            else
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
        }
        
        public async Task<T> GetById<T>(string Urlendpoint)
        {
            try
            {
                HttpClient client = _helper.Initial();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                HttpResponseMessage response = client.GetAsync(Urlendpoint).Result;
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<T>(data);
                var result = _mapper.Map<T>(res);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetList<T>(T entity, string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.GetAsync(Urlendpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                string stringJWT = await response.Content.ReadAsStringAsync();
                var jwt = JsonConvert.DeserializeObject<IEnumerable<T>>(stringJWT);
                return jwt;
            }
            else
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                var jwt = JsonConvert.DeserializeObject<IEnumerable<T>>(stringJWT);
                return jwt;
            }
        }

        public async Task<T> Delete<T>(string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
           //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.DeleteAsync(Urlendpoint).Result;
            response.EnsureSuccessStatusCode();
            string data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }

        public async Task<T> Delete<T>(T entity, string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.DeleteAsync(Urlendpoint).Result;
            response.EnsureSuccessStatusCode();
            string data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }

        public async Task<T> DeleteRange<T>(IEnumerable<T> entity, string Urlendpoint)
        {
            HttpClient client = _helper.Initial();
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            HttpResponseMessage response = client.PutAsync(Urlendpoint, contentData).Result;

            if (response.IsSuccessStatusCode)
            {
                string stringJWT = await response.Content.ReadAsStringAsync();
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
            else
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
                return jwt;
            }
        }
        
        //public async Task<T> Add(T entity, string Urlendpoint)
        //{
        //    HttpClient client = _helper.Initial();
        //    string stringData = JsonConvert.SerializeObject(entity);
        //    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

        //    HttpResponseMessage response = client.PostAsync(Urlendpoint, contentData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string stringJWT = await response.Content.ReadAsStringAsync();
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //    else
        //    {
        //        string stringJWT = response.Content.ReadAsStringAsync().Result;
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //}

        //public async Task<T> AddRange(IEnumerable<T> entity, string Urlendpoint)
        //{
        //    HttpClient client = _helper.Initial();
        //    string stringData = JsonConvert.SerializeObject(entity);
        //    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

        //    HttpResponseMessage response = client.PostAsync(Urlendpoint, contentData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string stringJWT = await response.Content.ReadAsStringAsync();
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //    else
        //    {
        //        string stringJWT = response.Content.ReadAsStringAsync().Result;
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //}

        //public async Task<T> Update(T entity, string Urlendpoint)
        //{
        //    HttpClient client = _helper.Initial();
        //    string stringData = JsonConvert.SerializeObject(entity);
        //    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

        //    HttpResponseMessage response = client.PutAsync(Urlendpoint, contentData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string stringJWT = await response.Content.ReadAsStringAsync();
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //    else
        //    {
        //        string stringJWT = response.Content.ReadAsStringAsync().Result;
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //}

        //public async Task<T> UpdateRange(IEnumerable<T> entity, string Urlendpoint)
        //{
        //    HttpClient client = _helper.Initial();
        //    string stringData = JsonConvert.SerializeObject(entity);
        //    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

        //    HttpResponseMessage response = client.PutAsync(Urlendpoint, contentData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string stringJWT = await response.Content.ReadAsStringAsync();
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //    else
        //    {
        //        string stringJWT = response.Content.ReadAsStringAsync().Result;
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //}

        //public async Task<T> GetById(T entity, string Urlendpoint)
        //{
        //    HttpClient client = _helper.Initial();
        //    string stringData = JsonConvert.SerializeObject(entity);
        //    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

        //    HttpResponseMessage response = client.GetAsync(Urlendpoint).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string stringJWT = await response.Content.ReadAsStringAsync();
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //    else
        //    {
        //        string stringJWT = response.Content.ReadAsStringAsync().Result;
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //}

        //public async Task<IEnumerable<T>> GetList(T entity, string Urlendpoint)
        //{
        //    HttpClient client = _helper.Initial();
        //    string stringData = JsonConvert.SerializeObject(entity);
        //    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

        //    HttpResponseMessage response = client.GetAsync(Urlendpoint).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string stringJWT = await response.Content.ReadAsStringAsync();
        //        var jwt = JsonConvert.DeserializeObject<IEnumerable<T>>(stringJWT);
        //        return jwt;
        //    }
        //    else
        //    {
        //        string stringJWT = response.Content.ReadAsStringAsync().Result;
        //        var jwt = JsonConvert.DeserializeObject<IEnumerable<T>>(stringJWT);
        //        return jwt;
        //    }
        //}

        //public async Task<T> Delete(T entity, string Urlendpoint)
        //{
        //    HttpClient client = _helper.Initial();
        //    string stringData = JsonConvert.SerializeObject(entity);
        //    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

        //    HttpResponseMessage response = client.DeleteAsync(Urlendpoint).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string stringJWT = await response.Content.ReadAsStringAsync();
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //    else
        //    {
        //        string stringJWT = response.Content.ReadAsStringAsync().Result;
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //}

        //public async Task<T> DeleteRange(IEnumerable<T> entity, string Urlendpoint)
        //{
        //    HttpClient client = _helper.Initial();
        //    string stringData = JsonConvert.SerializeObject(entity);
        //    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

        //    HttpResponseMessage response = client.PutAsync(Urlendpoint, contentData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string stringJWT = await response.Content.ReadAsStringAsync();
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //    else
        //    {
        //        string stringJWT = response.Content.ReadAsStringAsync().Result;
        //        var jwt = JsonConvert.DeserializeObject<T>(stringJWT);
        //        return jwt;
        //    }
        //}

    }
}

