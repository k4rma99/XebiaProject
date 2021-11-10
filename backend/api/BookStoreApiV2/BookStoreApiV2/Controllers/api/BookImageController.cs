using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStoreApiV2.Controllers.api
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookImageController : ApiController
    {
        
        [HttpPost]
        // POST: api/BookImage
        public string Post()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);


                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/Images/Book/"),
                    fileName
                );

                file.SaveAs(path);
            }

            return file.FileName;
        }

    }
}
