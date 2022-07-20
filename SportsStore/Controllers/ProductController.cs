using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repos;
        private readonly ILogger<ProductController> _logger;
        private SportsStoreContext context;
        private int pageSize = 4;

        public ProductController(ILogger<ProductController> logger, IProductRepository repos,
            SportsStoreContext context)
        {
            this.repos = repos;
            _logger = logger;
            this.context = context;
        }

        public IActionResult List(int page = 1)
        {
            ViewBag.Title = "All products";
            var selectedProducts = repos.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            return View(new ProductListViewModel()
            {
                Products = selectedProducts,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repos.Products.Count()
                }
            });
        }

        public IActionResult Index()
        {
            _logger.Log(LogLevel.Information, "Redirected...");
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create product";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product p)
        {
            ViewBag.Title = "Create product";
            if (ModelState.IsValid)
            {
                context.Products.Add(p);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(p);
        }
    }
}
