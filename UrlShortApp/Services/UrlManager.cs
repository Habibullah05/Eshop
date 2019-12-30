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
        private UrlContext _urlContext;
        private readonly IHashGenerationService generationService;

        public UrlManager(UrlContext urlContext, IHashGenerationService generationService)
        {
            _urlContext = urlContext;
            this.generationService = generationService;
        }

        public async Task<bool> CheckExist(string segment)
        {
            return await _urlContext.ShortUrls.AnyAsync(x => x.ShortURL == segment);
        }

        public async Task<UrlShort> ShortenUrl(string longUrl, string segment = "")
        {
            UrlShort url = await _urlContext.ShortUrls.FirstOrDefaultAsync(u => u.LongUrl == longUrl);
            if (url != null)
            {
                return url;
            }
            do
            {
                segment = generationService.NewSegment();
            }
            while (await CheckExist(segment));
            url = new UrlShort()
            {
                CreateUrl = DateTime.Now,
                LongUrl = longUrl,
                CountUse = 0,
                ShortURL = segment
            };
            await AddUrlShort(url);
            return url;
        }

        public async Task AddUrlShort(UrlShort url)
        {
            _urlContext.ShortUrls.Add(url);
            await _urlContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<UrlShort>> GetAllUrlShort()
        {
            return await _urlContext.ShortUrls.ToListAsync();
        }
        public async Task RemoveUrl(string id)
        {
            UrlShort url = await _urlContext.ShortUrls.FirstOrDefaultAsync(r => r.ShortURL == id);
            _urlContext.ShortUrls.Remove(url);
            await _urlContext.SaveChangesAsync();
        }


        public async Task<string> Click(string segment)
        {
            UrlShort url = await _urlContext.ShortUrls.FirstOrDefaultAsync(u => u.ShortURL == segment);
            url.CountUse += 1;
            await _urlContext.SaveChangesAsync();
            return url.LongUrl;
        }
    }
}
