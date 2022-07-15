using InventoryManagement.Data;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StockController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Stock> objStockList = _db.Stocks;
            return View(objStockList);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _db.Stocks.Add(stock);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stock);
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var stockFromDb = _db.Stocks.Find(id);

            if (stockFromDb == null)
            {
                return NotFound();
            }

            return View(stockFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _db.Stocks.Update(stock);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stock);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var stockFromDb = _db.Stocks.Find(id);

            if (stockFromDb == null)
            {
                return NotFound();
            }

            return View(stockFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _db.Stocks.Remove(stock);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stock);
        }
    }
}
