using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoMVC.Data;
using projetoMVC.Models;
using System.Diagnostics;

namespace projetoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly projetoMVCContext _context;

        public HomeController(ILogger<HomeController> logger, projetoMVCContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return _context.NoticiasModel != null ?
                               View(await _context.NoticiasModel.ToListAsync()) :
                               Problem("Entity set 'projetoMVCContext.NoticiasModel'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}