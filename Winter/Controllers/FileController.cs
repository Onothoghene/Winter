using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Winter.Helpers;

namespace Winter.Controllers
{
    public class FileController : Controller
    {
        public readonly IHttpClientLogic _httpClientLogic;

        public FileController(IHttpClientLogic httpClientLogic)
        {
            _httpClientLogic = httpClientLogic;
        }

        #region Methods

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

        #endregion

    }
}