using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortApp.Models.Entities;

namespace UrlShortApp.Models.Abstractions
{
    public interface IUrlManager
    {
        Task<UrlShort> ShortenUrl(string longUrl,  string segment = "");
        Task<string> Click(string segment);
        Task<IEnumerable<UrlShort>> GetAllUrlShort();
        Task RemoveUrl(string id);
    }
}
