using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortApp.Models.Abstractions;

namespace UrlShortApp.Models.Services
{
    public class HashGenerationService : IHashGenerationService
    {
        public string NewSegment()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}
