using Microsoft.AspNetCore.Mvc;
using SudokuSolver.Models;
using SudokuSolver.Service;
using System.Diagnostics;

namespace SudokuSolver.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SudokuMap map = new SudokuMap(true);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<int?> vals = map.Fields.Select(x => x.Value).ToList();

            return View(vals);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalculateSudoku(List<int?> vals)
        {
            int i = 0;
            foreach (var item in vals)
            {
                map.Fields[i].Value = item;
                i++;
            }

            Solution.Resolve(map);

            List<int?> vals2 = map.Fields.Select(x => x.Value).ToList();

            return View("Index", vals2);
        }
    }
}