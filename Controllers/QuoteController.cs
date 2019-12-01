using quoting_dojo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using quoting_dojo.DbConnection;

namespace quoting_dojo.Controllers
{
    public class QuoteController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Quotes")]
        public IActionResult Quotes(){
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quote");
            // To provide this data, we could use ViewBag or a View Model.  ViewBag shown here:
            ViewBag.Quotes = AllQuotes;
            return View();
        }
        [HttpPost("Quotes")]
        public IActionResult NewQuote(Quote quote){
            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO quote (Name, Content, Created_at) VALUES ('{quote.Name}', '{quote.Content}', NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            }
            else{
                return View("Index");
            }
        }
    }
}