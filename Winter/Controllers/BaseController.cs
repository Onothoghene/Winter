using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Winter.Controllers
{
    public class BaseController : Controller
    {
        public string UserId { get; set; } = "UserId";
    }
}
