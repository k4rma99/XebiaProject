using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BookStoreApiV2.Controllers.api
{
    public class CategoryImageController : ApiController
    {
       
        [HttpPost]
        // POST: api/CategoryImage
        public string Post()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);


                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/Images/Category/"),
                    fileName
                );

                file.SaveAs(path);
            }

            return file.FileName;
        }

    }
}
