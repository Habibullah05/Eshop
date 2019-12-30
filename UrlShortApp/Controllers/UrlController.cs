using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortApp.Models.Abstractions;
using UrlShortApp.Models.Entities;
using System.Web;
using UrlShortApp.ViewModels;

namespace UrlShortApp.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlManager _urlManager;

        public UrlController(IUrlManager urlManager)
        {
            this._urlManager = urlManager;
        }

   

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Index()
        {
            AddUrlViewModel url = new AddUrlViewModel();
            return View(url);
        
      }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(AddUrlViewModel addUrl)
        {
            UrlShort url = await _urlManager.ShortenUrl(HttpUtility.UrlDecode(addUrl.LongUrl), addUrl.ShortURL);
            AddUrlViewModel newAddUrl = new AddUrlViewModel()
            {
                ShortURL = string.Format("{0}://{1}", HttpContext.Request.Scheme, url.ShortURL)
            };
            return View(url);
       
        }

        [Microsoft.AspNetCore.Mvc.Route("{segment}")]
        public async Task<ActionResult> Click(string segment)
        {
           
            string longUrl= await _urlManager.Click(segment);

            return Redirect(longUrl);
        }
    }
}