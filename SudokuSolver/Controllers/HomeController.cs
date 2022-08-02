using Microsoft.AspNetCore.Mvc;
using SudokuSolver.Models;
using SudokuSolver.Service;
using System.Diagnostics;

namespace SudokuSolver.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SudokuMap map = new SudokuMap();

            map.Fields[0].Value = 5;
            map.Fields[1].Value = 7;
            map.Fields[2].Value = 3;
            map.Fields[3].Value = 8;
            map.Fields[4].Value = 9;
            map.Fields[5].Value = 1;
            map.Fields[6].Value = 4;
            map.Fields[7].Value = 6;

            Solution.Calculate(map);


            return View(map);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}