using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortenUrl
{
    public class ShortUrlRepository
    {
        private ShortUrlContext Context { get; set; }
        public ShortUrlRepository()
        {
            Context = new ShortUrlContext();
        }
        public string ShortenUrl(string url)
        {
            List<string> mapUrl = new List<string>{ "a", "b","c","d","e","f","g","h","i","j","k","l","m","n","o"
                                                    ,"p","q","r","s","t","u","v","w","x","y","z","A", "B","C","D","E","F","G","H","I","J","K",
                                                    "L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","0","1","2","3","4","5","6","7",
                                                    "8","9" };
            string shortUrl="";
            try
            {
                var newUrl = new UrlRecord();
                newUrl.UrlFull = url;
                Context.UrlRecords.ToList();
                Context.UrlRecords.Add(newUrl);
                Context.SaveChanges();
                var number = Context.UrlRecords.ToList()[Context.UrlRecords.Count()-1].UrlKey;
                var shortForm = new List<string>();
                while(number>0)
                {
                    var d = number % 62;
                    shortForm.Add(mapUrl[d]);
                    number = (int)number / 62;
                }
                shortForm.Reverse();
                foreach(var i in shortForm)
                {
                    shortUrl = shortUrl + i;
                }
            }
            catch(Exception ex)
            {
                shortUrl = null;
            }
            return shortUrl;
        }
        public string lengthenUrl(string shortUrl)
        {
            string fullUrl;
            List<string> mapUrl = new List<string>{ "a", "b","c","d","e","f","g","h","i","j","k","l","m","n","o"
                                                    ,"p","q","r","s","t","u","v","w","x","y","z","A", "B","C","D","E","F","G","H","I","J","K",
                                                    "L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","0","1","2","3","4","5","6","7",
                                                    "8","9" };
            try
            {
                List<int> extId = new List<int>();
                foreach(var i in shortUrl)
                {
                    var character = Convert.ToString(i);
                    extId.Add(mapUrl.IndexOf(character));
                }
                extId.Reverse();
                int count = 0;
                int id = 0;
                foreach(var i in extId)
                {
                    id += (i *(int) Math.Pow(62, count));
                    count += 1;
                }
                fullUrl = Context.UrlRecords.Where(n => n.UrlKey == id).FirstOrDefault().UrlFull;
            }
            catch(Exception ex)
            {
                fullUrl = null;
            }
            return fullUrl;
        }
    }
}