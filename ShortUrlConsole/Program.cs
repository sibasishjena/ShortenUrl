using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortenUrl;
namespace ShortUrlConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ShortUrlRepository das = new ShortUrlRepository();
            string str=Console.ReadLine();
            Console.WriteLine(das.lengthenUrl(str));
        }
    }
}
