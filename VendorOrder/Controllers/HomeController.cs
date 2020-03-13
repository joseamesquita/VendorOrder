using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorOrder.Models;

namespace VendorOrder.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }

}