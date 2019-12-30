using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortApp.ViewModels
{
    public class AddUrlViewModel
    {
        [MaxLength(6)]
        public string Hash { get; set; }
        public string ShortURL { get; set; }
        [Required]
        [Url]
        public string LongUrl { get; set; }
       
    }
}
