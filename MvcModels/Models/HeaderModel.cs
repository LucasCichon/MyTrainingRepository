using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcModels.Models
{
    public class HeaderModel
    {
        [FromHeader]
        public string Accept { get; set; }

        [FromHeader(Name ="Accept-Language")]
        public string AcceptLanguage { get; set; }

        [FromHeader(Name ="Accept-Encoding")]
        public string AcceptEncoding { get; set; }
    }
}
