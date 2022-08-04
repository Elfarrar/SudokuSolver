using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SudokuSolver.Controllers
{
    public class SudokuController : Controller
    {
        // GET: SudokuController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SudokuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SudokuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SudokuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SudokuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SudokuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SudokuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SudokuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
