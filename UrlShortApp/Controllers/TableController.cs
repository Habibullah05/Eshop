using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortApp.Models.Abstractions;

namespace UrlShortApp.Controllers
{
    public class TableController : Controller
    {
        private readonly IUrlManager _urlManager;

        public TableController(IUrlManager urlManager)
        {
            this._urlManager = urlManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _urlManager.GetAllUrlShort());
        }

        public async Task<IActionResult> DeleteUrl(string id)
        {
            await _urlManager.RemoveUrl(id);
            return RedirectToAction("Index");
            
        }
    }
}