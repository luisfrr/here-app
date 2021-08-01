using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Here.Web.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      var httpcontext = HttpContext.User;

      return View();
    }
  }
}
