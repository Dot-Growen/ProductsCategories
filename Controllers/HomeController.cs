using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCategories.Models;

namespace ProductsCategories.Controllers {
    public class HomeController : Controller {

        private MyContext _context;

        public HomeController (MyContext context) {
            _context = context;
        }

        [HttpGet ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpGet ("categories/{Id}")]
        public IActionResult CategoryView () {
            return View ();
        }

        [HttpGet ("products/{Id}")]
        public IActionResult ProductView(int Id) {
            return View ();
        }

        [HttpGet ("products")]
        public IActionResult Products () {
            return View ();
        }

        [HttpGet ("categories")]
        public IActionResult Categories () {
            return View ();
        }

    }
}