using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortenUrl.Models
{
    public class ShortUrlModel
    {
        public int UrlKey { get; set; }
        public string UrlFull { get; set; }
    }
}