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
        public IActionResult CategoryView (int Id) {
            ViewBag.ViewCate = _context.Categories
            .Where(c => c.CategoryId == Id)
            .SingleOrDefault();
            List<Product> allProd = _context.Products
                    .Include(p => p.AllCategories)
                    .ThenInclude(p => p.CatgoryInProduct)
                    .ToList();
            return View (allProd);
        }

        [HttpGet ("products/{Id}")]
        public IActionResult ProductView (int Id) {
            ViewBag.ViewProd = _context.Products
                .Where (p => p.ProductId == Id)
                .SingleOrDefault ();
            List<Category> allCate = _context.Categories
                .Include (c => c.AllProducts)
                .ThenInclude (c => c.ProductInCategory)
                .ToList ();
            return View (allCate);
        }

        [HttpGet ("products")]
        public IActionResult Products () {
            ViewBag.AllProducts = _context.Products.ToList ();
            return View ();
        }

        [HttpGet ("categories")]
        public IActionResult Categories () {
            ViewBag.AllCategories = _context.Categories.ToList();
            return View ();
        }

        [HttpPost ("addproduct")]
        public IActionResult AddProduct (Product newProd) {
            if(ModelState.IsValid) {
                _context.Products.Add (newProd);
                _context.SaveChanges ();
                Console.WriteLine (newProd.Name);
                return RedirectToAction ($"products/{newProd.ProductId}");
            } else {
                return RedirectToAction ("products");
            }
        }

        [HttpPost ("addcategory")]
        public IActionResult AddCategory (Category newCate) {
            if (ModelState.IsValid) {
                _context.Categories.Add (newCate);
                _context.SaveChanges ();
                Console.WriteLine (newCate.Name);
                return RedirectToAction ("Categories");
            } else {
                return RedirectToAction ("Categories");
            }
        }

        [HttpPost ("connect")]
        public IActionResult ConnectCategory (int ProductId, int CategoryId) {
                Association newAssociation = new Association();
                newAssociation.CategoryId = CategoryId;
                newAssociation.ProductId = ProductId;
                _context.Associations.Add (newAssociation);
                _context.SaveChanges ();
                Console.WriteLine (newAssociation.AssociationId);
                return RedirectToAction ("Products");
        }
    }
}