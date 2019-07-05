using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ShortenUrl.Repository
{
    public class ShortUrlMapper<Source, Destination>
        where Source : class
        where Destination : class
    {
        public ShortUrlMapper()
        {
            Mapper.CreateMap<UrlRecord, Models.ShortUrlModel>();
            Mapper.CreateMap<Models.ShortUrlModel, UrlRecord>();
        }

        public Destination Translate(Source sourceObj)
        {
            return Mapper.Map<Source, Destination>(sourceObj);
        }
    }
}