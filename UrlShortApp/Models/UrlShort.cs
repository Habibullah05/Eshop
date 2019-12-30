using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortApp.Models.Entities
{
    public class UrlShort
    {

        
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ShortURL { get; set; }
        [Required]
        [Url]
        public string LongUrl { get; set; }
        public DateTime CreateUrl { get; set; }
        public int CountUse { get; set; }
    }
}
