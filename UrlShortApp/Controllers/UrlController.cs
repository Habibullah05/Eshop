using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortApp.Models.Abstractions;
using UrlShortApp.Models.Entities;
using System.Web;



namespace UrlShortApp.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlManager _urlManager;

        public UrlController(IUrlManager urlManager)
        {
            this._urlManager = urlManager;
        }

        [Microsoft.AspNetCore.Mvc.Route("shorten")]
        public async Task<UrlShort> Shorten([FromUri]string url, [FromUri]string segment = "")
        {
            UrlShort shortUrl = await this._urlManager.ShortenUrl(HttpUtility.UrlDecode(url), segment);
            UrlShort urlModel = new UrlShort()
            {
                LongUrl = url,
                ShortURL = string.Format("{0}://{1}", HttpContext.Request.Scheme, shortUrl.ShortURL)
            };
            return urlModel;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Index()
        {
            UrlShort url = new UrlShort();
            return View(url);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(UrlShort lurl)
        {
            
            UrlShort sT = await _urlManager.ShortenUrl(HttpUtility.UrlDecode(lurl.LongUrl), lurl.ShortURL);             
            return View(sT);
            
           // return View();
        }

      //[Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("click")]
        public async Task<ActionResult> Click(string segment)
        {
           
            string longUrl= await _urlManager.Click(segment);

            return RedirectPermanent(longUrl);
        }
    }
}