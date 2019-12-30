using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortApp.Models.Abstractions;

namespace UrlShortApp.Models.Services
{
    public class HashGenerationService : IHashGenerationService
    {
        public string NewSegment(string segment )
        {
            if (segment == null)
            {
                return Guid.NewGuid().ToString().Substring(0, 9);
            }
           
                return segment + Guid.NewGuid().ToString().Substring(0, 9 - segment.Length);
            

           
        }
    }
}
