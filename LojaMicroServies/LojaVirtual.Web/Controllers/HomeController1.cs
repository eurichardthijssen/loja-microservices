﻿using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
