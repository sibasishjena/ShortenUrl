using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http;

namespace ShortenUrl.Controllers
{
    public class ShortUrlController : ApiController
    {
        [HttpGet]
        public JsonResult<string> ShortenUrl(string url)
        {
            try
            {
                ShortUrlRepository dal = new ShortUrlRepository();
                var shortUrl=dal.ShortenUrl(url);
                return Json<string>(shortUrl);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.GatewayTimeout)
                {
                    Content = new StringContent("Unable to connect to database", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.GatewayTimeout
                };
                throw new HttpResponseException(response);
            }
        }
        [HttpGet]
        public JsonResult<string> LengthenUrl(string url)
        {
            try
            {
                ShortUrlRepository dal = new ShortUrlRepository();
                var fullUrl = dal.lengthenUrl(url);
                return Json<string>(fullUrl);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.GatewayTimeout)
                {
                    Content = new StringContent("Unable to connect to database", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.GatewayTimeout
                };
                throw new HttpResponseException(response);
            }
        }
    }
}