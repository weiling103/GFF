﻿using SAEA.Http.Model;
using SAEA.MVC;
using System.IO;

namespace GFFServer.Controllers
{
    /// <summary>
    /// 文件处理
    /// </summary>
    public class FileController : Controller
    {
        [HttpPost]
        public ActionResult Upload()
        {
            var postFile = HttpContext.Request.PostFiles[0];
            var filePath = HttpContext.Server.MapPath("/Files");
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            filePath = Path.Combine(filePath, postFile.FileName);
            System.IO.File.WriteAllBytes(filePath, postFile.Data);
            return Content("Download?fileName=" + postFile.FileName);
        }


        public ActionResult Download(string fileName)
        {
            var filePath = Path.Combine(HttpContext.Server.MapPath("/Files"), fileName);
            return File(filePath);
        }
    }
}
