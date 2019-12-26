using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UrlShortApp.Models.Abstractions;
using UrlShortApp.Models.Entities;
using UrlShortApp.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Web.Http;

namespace UrlShortApp.Models.Services
{
    public class UrlManager : IUrlManager
    {
        private  UrlContext _urlContext;
        

        public UrlManager(UrlContext urlContext)
        {
            _urlContext = urlContext;
        }

        public async Task<UrlShort> ShortenUrl(string longUrl,  string segment = "")
        {
            
                UrlShort url = await  _urlContext.ShortUrls.FirstOrDefaultAsync(u => u.LongUrl == longUrl);            
                segment = this.NewSegment();
          
          
            url = new UrlShort()
                {
                    CreateUrl = DateTime.Now,
                    LongUrl = longUrl,
                    CountUse = 0,
                    ShortURL =   segment
                };
                _urlContext.ShortUrls.Add(url);
                _urlContext.SaveChanges();
                return url;
            
        }


        public Task<string> Click(string segment)
        {
            return Task.Run(() =>
            {
                UrlShort url = _urlContext.ShortUrls.FirstOrDefault(u => u.ShortURL == segment);
                url.CountUse += 1;
                _urlContext.SaveChanges();
                return url.LongUrl;
            });

        }

        private string NewSegment()
        {
            while (true)
            {
                string segment = Guid.NewGuid().ToString().Substring(0, 6);
                if (!_urlContext.ShortUrls.Where(u => u.ShortURL == segment).Any())
                {
                    return segment;
                }
               
             
            }
          

        }


    }
}
